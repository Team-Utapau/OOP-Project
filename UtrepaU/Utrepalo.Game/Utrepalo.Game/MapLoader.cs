using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.GameObjects;
using Utrepalo.Game.GameObjects.Walls;

namespace Utrepalo.Game
{
    using GameObjects.Enemies;
    using GameObjects.Resources.Items;

    public class MapLoader
    {
        public static List<GameObject> LoadMap(SpriteBatch spriteBatch)
        {
            string map = @"../../../Resources/mapFinal.txt";

            List<GameObject> gameObjects = new List<GameObject>();

            try
            {
                using (StreamReader sr = new StreamReader(map))
                {
                    int positionY = 0;
                    int positionX = 0;

                    const int largeTextureSize = 30;

                    string line = sr.ReadToEnd();

                    for (int i = 0; i < line.Length; i++)
                    {
                        char currentSymbol = line[i];
                        Rectangle rect;

                        switch (currentSymbol)
                        {
                            case 'w':
                                rect = new Rectangle(
                                    positionX -60,
                                    positionY,
                                    largeTextureSize,
                                    largeTextureSize);

                                gameObjects.Add(new StoneWall(GameEngine.BasisWallTexture, rect));
                                break;
                            case 'B':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset-7,
                                    positionY - GameEngine.Offset-5,
                                    50,
                                    50);

                                gameObjects.Add(new Boyko(GameEngine.BoykoTexture, rect));
                                break;
                            case 'P':
                                rect = new Rectangle(
                                    positionX ,
                                    positionY ,
                                   25,25);

                                gameObjects.Add(new Player(GameEngine.PlayerTexture, rect));
                                break;
                            case 'T':
                                rect = new Rectangle(
                                    positionX ,
                                    positionY ,
                                    20,
                                    25);

                                gameObjects.Add(new HealingPotion(GameEngine.HealingPotionTexture, rect));
                                break;
                            case 'C':
                                rect = new Rectangle(
                                    positionX,
                                    positionY ,
                                   30,
                                    30);

                                gameObjects.Add(new Coin(GameEngine.CoinTexture, rect));
                                break;
                            case 'E':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset-10,
                                    positionY - GameEngine.Offset,
                                    30,
                                    30);

                                gameObjects.Add(new Minion(GameEngine.EnemyTexture, rect));
                                break;
                            case '\n':
                                positionY += largeTextureSize;
                                positionX = largeTextureSize;
                                break;
                        }

                        positionX += largeTextureSize;
                    }
                }

                return gameObjects;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
