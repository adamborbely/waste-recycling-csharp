using System;

namespace WasteRecycling
{
    public class Dustbin
    {
        public string Color;
        public PaperGarbage[] PaperContent;
        public PlasticGarbage[] PlasticContent;
        public Garbage[] HouseWasteContent;

        public Dustbin(string color)
        {
            Color = color;
            PaperContent = new PaperGarbage[15];
            PlasticContent = new PlasticGarbage[15];
            HouseWasteContent = new Garbage[15];
        }

        private int Cointains(Garbage[] garbages)
        {
            int result = garbages.Length;
            foreach (var elem in garbages)
            {
                if (elem == null)
                {
                    result--;
                }
            }
            return result;
        }

        public void DisplayContents()
        {
            System.Console.WriteLine(Color + " Dustbin!");
            System.Console.WriteLine();
            System.Console.WriteLine(@"House waste content: {0} item(s)", Cointains(HouseWasteContent));
            System.Console.WriteLine();
            if (HouseWasteContent.Length > 0)
            {
                foreach (var elem in HouseWasteContent)
                {
                    if (elem != null)
                    {
                        System.Console.WriteLine(elem.Name);
                    }
                }
            }
            System.Console.WriteLine();
            System.Console.WriteLine(@"Paper content: {0} item(s)", Cointains(PaperContent));
            System.Console.WriteLine();
            if (PaperContent.Length > 0)
            {
                foreach (var elem in PaperContent)
                {
                    if (elem != null)
                    {
                        System.Console.WriteLine(elem.Name);
                    }
                }
            }
            System.Console.WriteLine();
            System.Console.WriteLine(@"Plastic content: {0} item(s)", Cointains(PlasticContent));
            System.Console.WriteLine();
            if (PlasticContent.Length > 0)
            {
                foreach (var elem in PlasticContent)
                {
                    if (elem != null)
                    {
                        System.Console.WriteLine(elem.Name);
                    }
                }
            }
        }
        public void ThrowOutGarbage(Garbage garbage)
        {
            if (garbage is PlasticGarbage)
            {
                PlasticGarbage plastic = (PlasticGarbage)garbage;

                if (plastic.Cleaned)
                {
                    int index = -1;
                    for (int i = 0; i < PlasticContent.Length; i++)
                    {
                        if (PlasticContent[i] == null)
                        {
                            index = i;
                        }
                    }
                    if (index == -1)
                    {
                        throw new DustbinContentException("Plastic garbage need to be emptied");
                    }
                    PlasticContent[index] = plastic;
                }
                else
                {
                    throw new DustbinContentException("Plastic is dirty!");
                }
            }
            else if (garbage is PaperGarbage)
            {
                PaperGarbage paper = (PaperGarbage)garbage;
                if (paper.Squeezed)
                {
                    int index = -1;
                    for (int i = 0; i < PaperContent.Length; i++)
                    {
                        if (PaperContent[i] == null)
                        {
                            index = i;
                        }
                    }
                    if (index == -1)
                    {
                        throw new DustbinContentException("Paper garbage need to be emptied");
                    }
                    PaperContent[index] = paper;
                }
                else
                {
                    throw new DustbinContentException("The paper need to be squezzed first!");
                }
            }
            else if (garbage is Garbage)
            {
                int index = -1;
                for (int i = 0; i < HouseWasteContent.Length; i++)
                {
                    if (HouseWasteContent[i] == null)
                    {
                        index = i;
                    }
                }
                if (index == -1)
                {
                    throw new DustbinContentException("House waste need to be emptied");
                }
                HouseWasteContent[index] = garbage;
            }
            else
            {
                throw new DustbinContentException("That is some gold you wanna throw out!");
            }

        }

        public void EmptyContents()
        {
            for (int i = 0; i < PaperContent.Length; i++)
            {
                PaperContent[i] = null;
                PlasticContent[i] = null;
                HouseWasteContent[i] = null;
            }
        }

    }

}
