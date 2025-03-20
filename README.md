# HSE_Bank
C# school projects for discipline Software Design.

Отчет по проекту «Учет финансов»

1. Общая идея решения

Проект представляет собой консольное приложение для учета финансов, включающее управление счетами, категориями и операциями (доходы/расходы). Реализованы основные требования:

✅ Работа с доменной моделью (создание, редактирование, удаление счетов, категорий, операций).
✅ Аналитика (подсчет разницы доходов и расходов за период).
✅ Импорт и экспорт данных (JSON, CSV, YAML).
✅ Измерение времени выполнения операций.

Дополнительно:

Реализован DI-контейнер для управления зависимостями.

Использованы паттерны проектирования для структурирования кода.

Обеспечена гибкость и расширяемость за счет отделения логики хранения данных от бизнес-логики.

2. Реализованные принципы SOLID и GRASP

SOLID:

S (Single Responsibility) – каждый класс отвечает за одну задачу (BankAccount, Operation, FinancialFacade).

O (Open-Closed) – новые форматы экспорта реализуются без изменения кода Operation (IDataExporterVisitor).

L (Liskov Substitution) – IDataExporterVisitor позволяет использовать разные экспортёры (JsonExporter, CsvExporter).

I (Interface Segregation) – отдельные интерфейсы IBankAccountRepository, ICategoryRepository, IOperationRepository.

D (Dependency Inversion) – используется DI-контейнер (Microsoft.Extensions.DependencyInjection).

GRASP:

High Cohesion & Low Coupling – разделение на модули (FinanceApp.Domain, FinanceApp.Repositories, FinanceApp.IO).

Controller – фасад FinancialFacade управляет операциями.

Creator – фабрика DomainFactory отвечает за создание объектов.

3. Использованные паттерны GoF

Паттерн

Описание

Реализация

Фасад (Facade)

Объединяет логику работы с финансовыми операциями

FinancialFacade

Команда (Command)

Инкапсулирует команды пользователя

AddOperationCommand

Декоратор (Decorator)

Добавляет измерение времени к командам

TimeMeasureCommandDecorator

Фабрика (Factory)

Централизует создание объектов

DomainFactory

Посетитель (Visitor)

Экспорт данных в разные форматы

IDataExporterVisitor, JsonExporter, CsvExporter

Шаблонный метод (Template Method)

Унифицирует импорт данных

DataImporter, JsonImporter, CsvImporter

4. Инструкция по запуску

Установка зависимостей

Перед запуском убедитесь, что установлены все необходимые пакеты:

Запуск проекта

Клонировать репозиторий:

Собрать проект:

Запустить приложение:

Использование

Создать счет → Ввести название и баланс.

Создать категорию → Ввести название и тип (доход/расход).

Добавить операцию → Ввести ID счета, ID категории, сумму.

Показать разницу доходов/расходов → Ввести период.

Импорт/экспорт данных → Выбрать JSON, CSV, YAML.

Приложение готово к использованию! 🚀
