using System;

namespace Star
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("Erreur le nombre d'argument passé n'est pas bon");
                Console.WriteLine("ex: ./star 1");

                return;
            }

            int size = default;

            if (!int.TryParse(args[0], out size))
            {
                Console.Error.WriteLine("Erreur l'argument passé n'est pas un nombre correct");
                Console.WriteLine("ex: ./star 1");

                return;
            }

            if (size == 0)
                return;

            int ecartBranche = size * 2;
            ecartBranche -= ecartBranche % 2 == 0 ? 1 : 0;
            ecartBranche = ecartBranche < 1 ? 1 : ecartBranche;
            int largeurPlat = (size * 2) + 1;
            int width = largeurPlat * 2 + ecartBranche;
            width -= width % 2 == 0 ? 1 : 0;
            int height = (size * 4) + 1;
            string etoile = string.Empty;

            for (int i = 0; i < height; i++)
            {
                etoile += " ";
                int starNeeded;

                if (i == 0 || i == height - 1)
                    starNeeded = 1;
                else if (i == size || i == height - size - 1)
                    starNeeded = largeurPlat * 2;
                else
                    starNeeded = 2;

                int count = starNeeded;
                int pos = 1;
                while (pos <= width)
                {                    
                    if (starNeeded == 1)
                    {
                        if (pos == (width / 2) + 1)
                        {
                            etoile += "*";
                            count--;
                        }
                        else
                            etoile += " ";
                    }
                    else if (starNeeded == 2)
                    {
                        if (i < height / 4)
                        {
                            if (pos < width / 2 - i + 1 || (pos > width / 2 - i + 1 && pos < width / 2 + i + 1))
                                etoile += " ";
                            else
                            {
                                etoile += "*";
                                count--;
                            }
                        }
                        else if (i > height / 4 + height / 2)
                        {
                            if (pos < width / 2 - (height - i - 2) || (pos > width / 2 - (height - i - 2) && pos < width / 2 + (height - i)))
                                etoile += " ";
                            else
                            {
                                etoile += "*";
                                count--;
                            }
                        }
                        else if (i > height / 4 && i < height / 4 + height / 2)
                        {
                            if (i < height / 2)
                            {
                                if (pos < width / 2 - (height - i - 2) || (pos > width / 2 - (height - i - 2) && pos < width / 2 + (height - i)))
                                    etoile += " ";
                                else
                                {
                                    etoile += "*";
                                    count--;
                                }
                            }
                            else if (i == height / 2)
                            {
                                if (pos == (largeurPlat / 2) + 1 || pos == width - (largeurPlat / 2))
                                {
                                    etoile += "*";
                                    count--;
                                }
                                else
                                    etoile += " ";
                            }
                            else
                            {
                                if (pos < width / 2 - i + 1 || (pos > width / 2 - i + 1 && pos < width / 2 + i + 1))
                                    etoile += " ";
                                else
                                {
                                    etoile += "*";
                                    count--;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (pos > largeurPlat && pos <= largeurPlat + ecartBranche)
                            etoile += " ";
                        else
                        {
                            etoile += "*";
                            count--;
                        }
                    }

                    if (count == 0)
                        break;

                    pos++;
                }

                etoile += "\n";
            }

            Console.WriteLine(etoile);
        }
    }
}
