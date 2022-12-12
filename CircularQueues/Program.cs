using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CircularQueues
{
    class Program
    {
        int FRONT, REAR, max = 5;
        int[] queue_array = new int[5];
        public Program()
        {
            FRONT = -1;
            REAR = -1;
        }
        public void insert(int element)
        {
            if ((FRONT == 0 && REAR == max -1) || (FRONT == +1))
            {
                Console.WriteLine("\nQueue overflow\n");
                return;
            }
            if (FRONT == -1)
            {
                FRONT = 0;
                REAR = 0;
            }
            else
            {
                if (REAR == max - 1)
                    REAR = 0;
                else
                    REAR = REAR + 1;
            }
            queue_array[REAR] = element;
        }
        public void remove()
        {
            if (FRONT ==-1)
            {
                Console.WriteLine("Queue underflow\n");
                return;
            }
            Console.WriteLine("\nThe element deleted from the queue is: " + queue_array[FRONT] + "\n");
            if (FRONT == REAR)
            {
                FRONT = -1;
                REAR = -1;
            }
            else
            {
                if (FRONT == max - 1)
                    FRONT = 0;
                else
                    FRONT = FRONT + 1;
            }
        }
        public void display()
        {
            int FRONT_position = FRONT;
            int REAR_position = REAR;

            if (FRONT == -1)
            {
                Console.WriteLine("Queue is empty\n");
                return;
            }
            Console.WriteLine("\nElements in the queue are ...........\n");
            if (FRONT_position <= REAR_position)
            {
                while (FRONT_position <= REAR_position)
                {
                    Console.Write(queue_array[FRONT_position] + " ");
                    FRONT_position++;
                }
                Console.WriteLine();
            }  
            else
            {
                while (FRONT_position <= max - 1)
                {
                    Console.Write(queue_array[FRONT_position] + " ");
                    FRONT_position++;
                }
                FRONT_position = 0;
                while (FRONT_position <= REAR_position)
                {
                    Console.Write(queue_array[FRONT_position] + " ");
                    FRONT_position++;
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Program queue = new Program();
            char ch;
            while (true)
            {
                try
                {
                    Console.WriteLine("Menu");
                    Console.WriteLine("1. Implement insert operation");
                    Console.WriteLine("2. Implement delete operation");
                    Console.WriteLine("3. Display values");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4):  ");
                    ch = Convert.ToChar(Console.Read());
                    Console.WriteLine();
                    switch (ch)
                    {
                        case '1':
                            {
                                Console.Write("Enter a number: ");
                                int num = Convert.ToInt32(System.Console.ReadLine());
                                Console.WriteLine();
                                queue.insert(num);
                            }
                            break;
                        case '2':
                            {
                                queue.remove();
                            }
                            break;
                        case '3':
                            {
                                queue.display();
                            }
                            break;
                    }
                }
            }
        }
    }
}