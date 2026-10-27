#include <iomanip>
#include <iostream>
#include <limits>
#include <string>
#include <vector>

struct Employee {
    int id;
    std::string name;
    double hoursWorked;
    double hourlyRate;
};

d ouble calculateGrossPay(const Employee& employee) {
    constexpr double overtimeThreshold = 40.0;
    if (employee.hoursWorked <= overtimeThreshold) {
        return employee.hoursWorked * employee.hourlyRate;
    }
    return overtimeThreshold * employee.hourlyRate +
           (employee.hoursWorked - overtimeThreshold) * employee.hourlyRate * 1.5;
}
 
int main() {
    std::vector<Employee> employees;
    int count;

    std::cout << "Payroll System\nEnter number of employees: ";
    while (!(std::cin >> count) || count < 1) {
        std::cout << "Enter a whole number greater than zero: ";
        std::cin.clear();
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }
    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

    for (int i = 0; i < count; ++i) {
        Employee employee{};
        std::cout << "\nEmployee " << i + 1 << "\nName: ";
        std::getline(std::cin, employee.name);

        std::cout << "ID: ";
        while (!(std::cin >> employee.id)) {
            std::cout << "Enter a valid integer ID: ";
            std::cin.clear();
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
        }
        std::cout << "Hours worked: ";
        while (!(std::cin >> employee.hoursWorked) || employee.hoursWorked < 0) {
            std::cout << "Enter a valid non-negative number of hours: ";
            std::cin.clear();
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
        }
        std::cout << "Hourly rate: ";
        while (!(std::cin >> employee.hourlyRate) || employee.hourlyRate < 0) {
            std::cout << "Enter a valid non-negative hourly rate: ";
            std::cin.clear();
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
        }
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
        employees.push_back(employee);
    }

    std::cout << "\nPayroll Report\n"
              << std::left << std::setw(8) << "ID" << std::setw(24) << "Name"
              << std::right << std::setw(12) << "Hours" << std::setw(14) << "Rate"
              << std::setw(16) << "Gross Pay\n";
    std::cout << std::string(74, '-') << '\n' << std::fixed << std::setprecision(2);

    double totalPayroll = 0.0;
    for (const Employee& employee : employees) {
        const double grossPay = calculateGrossPay(employee);
        totalPayroll += grossPay;
        std::cout << std::left << std::setw(8) << employee.id
                  << std::setw(24) << employee.name << std::right
                  << std::setw(12) << employee.hoursWorked
                  << std::setw(14) << employee.hourlyRate
                  << std::setw(16) << grossPay << '\n';
    }
    std::cout << std::string(74, '-') << "\nTotal payroll: $"
              << totalPayroll << '\n';
    return 0;
}