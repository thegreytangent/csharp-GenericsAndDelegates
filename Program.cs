using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouseManagementSystemAPI;

namespace HardwareWarehouseManagementSystem
{



    
    internal class Program
    {
        const int Batch_Size = 5;

        static void Main(string[] args)
        {


            CustomQueue<HardwareItem> hardwareItemQueue = new CustomQueue<HardwareItem>();
            hardwareItemQueue.CustomQueueEvent += _customQueue_CustomQueueEvent;

            System.Threading.Thread.Sleep(2000);

            //comes into stock - device scans a bar code or QR code
            hardwareItemQueue.AddItem(new Drill { Id = 1, Name = "Drill 1", Type = "Drill", UnitValue = 20.00m, Quantity = 10 });

            System.Threading.Thread.Sleep(1000);

            hardwareItemQueue.AddItem(new Drill { Id = 2, Name = "Drill 2", Type = "Drill", UnitValue = 30.00m, Quantity = 20 });

            System.Threading.Thread.Sleep(2000);

            hardwareItemQueue.AddItem(new Ladder { Id = 3, Name = "Ladder 1", Type = "Ladder", UnitValue = 100.00m, Quantity = 5 });

            System.Threading.Thread.Sleep(1000);

            hardwareItemQueue.AddItem(new Hammer { Id = 4, Name = "Hammer 1", Type = "Hammer", UnitValue = 10.00m, Quantity = 80 });
            System.Threading.Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new PaintBrush { Id = 5, Name = "Paint Brush 1", Type = "PaintBrush", UnitValue = 5.00m, Quantity = 100 });
            System.Threading.Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new PaintBrush { Id = 6, Name = "Paint Brush 2", Type = "PaintBrush", UnitValue = 5.00m, Quantity = 100 });
            System.Threading.Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new PaintBrush { Id = 7, Name = "Paint Brush 3", Type = "PaintBrush", UnitValue = 5.00m, Quantity = 100 });
            System.Threading.Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new Hammer { Id = 8, Name = "Hammer 2", Type = "Hammer", UnitValue = 11.00m, Quantity = 80 });
            System.Threading.Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new Hammer { Id = 9, Name = "Hammer 3", Type = "Hammer", UnitValue = 13.00m, Quantity = 80 });
            System.Threading.Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new Hammer { Id = 10, Name = "Hammer 4", Type = "Hammer", UnitValue = 14.00m, Quantity = 80 });
            System.Threading.Thread.Sleep(3000);

            Console.ReadKey();

        }

        private static void ProcessItems(CustomQueue<HardwareItem> _customQue) {

            while (_customQue.QueueLength > 0 ) {

                System.Threading.Thread.Sleep(3000);

                HardwareItem hardwareItem = _customQue.GetItem();
            }
        
        }

        private static void _customQueue_CustomQueueEvent(CustomQueue<HardwareItem> sender, QueEventArgs eventArgs)
        {
            Console.Clear();
            if (sender.QueueLength > 0)
            {
                Console.WriteLine(eventArgs.Message);
                Console.WriteLine();
                Console.WriteLine();

                WriteValuesInQueueToScreen(sender);

                if (sender.QueueLength == Batch_Size) {
                    ProcessItems(sender);
                }
                

                

            }
            else {
                Console.WriteLine($"All items has been processed");
            }
        }

        private static void WriteValuesInQueueToScreen(CustomQueue<HardwareItem> _items) {
            foreach (var item in _items) {
                Console.WriteLine(
                    $"{item.Id, -6}{item.Name, -15}" +
                    $"{item.Type, -20}{item.Quantity, 10}" +
                    $"{item.UnitValue,10}"
                   );
            }
        }
    }

    public abstract class HardwareItem : IEntityPrimaryProperties, IEntityAdditionalProperties
    {
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }



    public interface IDrill {
         string DrillBrandName { get; set; }
    }
    public class Drill : HardwareItem, IDrill
    {
        public string DrillBrandName {
            get; set;
        }
    }

    public interface ILadder
    {
        string LadderBrandName { get; set; }
    }
    public class Ladder : HardwareItem, ILadder
    {
        public string LadderBrandName
        {
            get; set;
        }
    }


    public interface IPaintBrush
    {
        string PaintBrushBrandName { get; set; }
    }
    public class PaintBrush : HardwareItem, IPaintBrush
    {
        public string PaintBrushBrandName
        {
            get; set;
        }
    }

    public interface IHammer
    {
        string HammerBrandName { get; set; }
    }
    public class Hammer : HardwareItem, IHammer
    {
        public string HammerBrandName
        {
            get; set;
        }
    }


}
