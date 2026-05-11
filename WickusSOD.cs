namespace FR1.PL
{
    class Program
    {
        static SmartDeviceBL bl = new SmartDeviceBL();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Smart Device Management System!");
            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Add a new smart device");
                Console.WriteLine("2. View all smart devices");
                Console.WriteLine("3. Exit");
                Console.Write("Your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddSmartDevice();
                        break;
                    case "2":
                        ViewSmartDevices();
                        break;
                    case "3":
                        Console.WriteLine("Exiting the application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void AddSmartDevice()
        {
            Console.Write("Add device name: ");
            string name = Console.ReadLine();
            Console.Write("Enter device type: ");
            string type = Console.ReadLine();
            SmartDevice device = new SmartDevice { Name = name, Type = type };
            bl.AddSmartDevice(device);
            Console.WriteLine("Smart device added successfully!");
        }
        static void ViewSmartDevices()
        {
            var devices = bl.GetAllSmartDevices();
            if (devices.Count == 0)
            {
                Console.WriteLine("No smart devices found.");
                return;
            }
            Console.WriteLine("\nList of Smart Devices:");
            foreach (var device in devices)
            {
                Console.WriteLine($"ID: {device.Id}, Name: {device.Name}, Type: {device.Type}");
            }

        }
        static void UpdateSmartDevice()
        {
            Console.Write("Enter the ID of the device to update: ");
            int id = int.Parse(Console.ReadLine());
            var device = bl.GetSmartDeviceById(id);
            if (device == null)
            {
                Console.WriteLine("Device not found.");
                return;
            }
            Console.Write("Enter new device name: ");
            string name = Console.ReadLine();
            Console.Write("Enter new device type: ");
            string type = Console.ReadLine();
            device.Name = name;
            device.Type = type;
            bl.UpdateSmartDevice(device);
            Console.WriteLine("Smart device updated successfully!");
        }
    
    static void DeleteSmartDevice()
        {
            Console.Write("Enter the ID of the device to delete: ");
            int id = int.Parse(Console.ReadLine());
            bl.DeleteSmartDevice(id);
            Console.WriteLine("Smart device deleted successfully!");
        }
    }
}
