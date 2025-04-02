using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace files
{
    public class FileManager
    {
        private string fileName;
        public FileManager(string fileName)
        {
            this.fileName = fileName;
        }

        public List<Cars> Read()
        {
            List<Cars> all = new List<Cars>();

            try
            {
                File.ReadAllLines(fileName, Encoding.UTF8).Skip(1).ToList().ForEach(line => all.Add(new Cars(line)));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return all;
        }

        public void Write(Cars car)
        {
            using (StreamWriter write = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                write.Write($"\n{car.Manufacturer};{car.Model};{car.Power};{car.Weight}");
            }
        }

        public void Update(int num, Cars carN)
        {
            List<Cars> list = Read();
            using (StreamWriter write = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                int temp = 0;
                list.ForEach(car =>
                {
                    if (num == temp)
                    {
                        write.Write($"\n{carN.Manufacturer};{carN.Model};{carN.Power};{carN.Weight}");
                    }
                    else
                    {
                        write.Write($"\n{car.Manufacturer};{car.Model};{car.Power};{car.Weight}");
                    }
                    temp++;
                });
            }
        }
    }
}
