namespace TestProject
{
    public class UnitTest1
    {
        //Тест на проверку что файл не пустой
        [Fact]
        public void TestOne()
        {
            string[] massivroute = null;
            bool ReadFile()
            {
                using (StreamReader reader = new StreamReader("route.txt"))
                {
                    bool bollperemen = false;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        massivroute = line.Split("\n");
                        line = reader.ReadLine();
                    }
                    if (massivroute.Length > 0)
                    {
                        bollperemen = true;
                    }
                    return bollperemen;
                }
            }

            Assert.Equal(true, ReadFile());
        }
    }
}
