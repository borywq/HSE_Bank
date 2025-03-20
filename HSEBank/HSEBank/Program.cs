using Microsoft.Extensions.DependencyInjection;
using HSEBank.Domain;
using HSEBank.Export;
using HSEBank.Import;
using HSEBank.Facades;
using HSEBank.Repositories;

namespace FinanceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // DI-контейнер
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IBankAccountRepository, InMemoryBankAccountRepository>()
                .AddSingleton<ICategoryRepository, InMemoryCategoryRepository>()
                .AddSingleton<IOperationRepository, InMemoryOperationRepository>()
                .AddSingleton<BankFacade>()
                .BuildServiceProvider();

            var facade = serviceProvider.GetService<BankFacade>();
            var operationRepo = serviceProvider.GetService<IOperationRepository>();

            Console.WriteLine("Добро пожаловать в систему HSEBank!");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить банковский счет");
                Console.WriteLine("2. Добавить категорию");
                Console.WriteLine("3. Добавить операцию");
                Console.WriteLine("4. Показать разницу доходов и расходов за период");
                Console.WriteLine("5. Показать все счета");
                Console.WriteLine("6. Показать все категории");
                Console.WriteLine("7. Показать все операции");
                Console.WriteLine("8. Экспорт данных");
                Console.WriteLine("0. Выход");

                Console.Write("Ваш выбор: ");
                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Введите название счета: ");
                            var accountName = Console.ReadLine();
                            Console.Write("Введите начальный баланс: ");
                            decimal initialBalance = decimal.Parse(Console.ReadLine());
                            var account = facade.CreateAccount(accountName, initialBalance);
                            Console.WriteLine($"Счет создан. ID: {account.Id}");
                            break;
                        case "2":
                            Console.Write("Введите название категории: ");
                            var categoryName = Console.ReadLine();
                            Console.Write("Выберите тип (0 - Доход, 1 - Расход): ");
                            int typeInt = int.Parse(Console.ReadLine());
                            var categoryType = (CategoryType)typeInt;
                            var category = facade.CreateCategory(categoryName, categoryType);
                            Console.WriteLine($"Категория создана. ID: {category.Id}");
                            break;
                        case "3":
                            Console.Write("Введите ID счета: ");
                            var accountId = Guid.Parse(Console.ReadLine());
                            Console.Write("Введите ID категории: ");
                            var categoryId = Guid.Parse(Console.ReadLine());
                            Console.Write("Введите тип операции (0 - Доход, 1 - Расход): ");
                            int opTypeInt = int.Parse(Console.ReadLine());
                            var opType = (OperationType)opTypeInt;
                            Console.Write("Введите сумму операции: ");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            Console.Write("Введите описание операции: ");
                            var description = Console.ReadLine();
                            var operation = facade.AddOperation(opType, accountId, amount, DateTime.Now, categoryId, description);
                            Console.WriteLine("Операция добавлена.");
                            break;
                        case "4":
                            Console.Write("Введите начальную дату (yyyy-MM-dd): ");
                            var startDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Введите конечную дату (yyyy-MM-dd): ");
                            var endDate = DateTime.Parse(Console.ReadLine());
                            var diff = facade.CalculateDifference(startDate, endDate);
                            Console.WriteLine($"Разница доходов и расходов: {diff}");
                            break;
                        case "5":
                            Console.WriteLine("Счета:");
                            foreach (var acc in facade.GetAllAccounts())
                            {
                                Console.WriteLine($"ID: {acc.Id}, Название: {acc.Name}, Баланс: {acc.Balance}");
                            }
                            break;
                        case "6":
                            Console.WriteLine("Категории:");
                            foreach (var cat in facade.GetAllCategories())
                            {
                                Console.WriteLine($"ID: {cat.Id}, Название: {cat.Name}, Тип: {cat.Type}");
                            }
                            break;
                        case "7":
                            Console.WriteLine("Операции:");
                            foreach (var op in facade.GetAllOperations())
                            {
                                Console.WriteLine($"ID: {op.Id}, Тип: {op.Type}, Сумма: {op.Amount}, Дата: {op.Date}, Категория ID: {op.CategoryId}");
                            }
                            break;
                        case "8":
                            Console.Write("Введите путь для сохранения файла экспорта: ");
                            string exportPath = Console.ReadLine();
                            var operations = operationRepo.GetAll().ToList();
                            new JsonExporter().Export(operations, exportPath);
                            Console.WriteLine("Данные успешно экспортированы.");
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
