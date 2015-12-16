using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.GameObjects;
using Utrepalo.Game.GameObjects.Walls;
using Utrepalo.Game.Test;

namespace Utrepalo.Game
{
    using GameObjects.Resources.Items;

    public class MapLoader
    {
        public static List<GameObject> LoadMap(SpriteBatch spriteBatch/*, GameLevel level*/)
        {
            string map = @"../../../Resources/mapFinal.txt";
            //switch (level)
            //{
            //    case GameLevel.Easy:
            //        map = @"../../../Resources/Maps/Map_TrainingFields.txt";
            //        break;
            //    case GameLevel.Medium:
            //        map = @"../../../Resources/Maps/Map_OnEnemyTerritory.txt";
            //        break;
            //    case GameLevel.Hard:
            //        map = @"../../../Resources/Maps/Map_Glory.txt";
            //        break;
            //    default:
            //        throw new MapNotFoundException("The specified map is not implemented.");
            //}

            List<GameObject> gameObjects = new List<GameObject>();

            try
            {
                using (StreamReader sr = new StreamReader(map))
                {
                    int positionY = 0;
                    int positionX = 0;

                    const int LargeTextureSize = 30;

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
                                    40,
                                    LargeTextureSize);

                                gameObjects.Add(new StoneWall(GameEngine.BasisWallTexture, rect));
                                break;
                            //case 'B':
                            //    rect = new Rectangle(
                            //        positionX - GameEngine.Offset,
                            //        positionY - GameEngine.Offset,
                            //        LargeTextureSize,
                            //        LargeTextureSize);

                            //    gameObjects.Add(new Bush(GameEngine.BasicBushTexture, rect));
                            //    break;
                            //case 'I':
                            //    rect = new Rectangle(
                            //        positionX - GameEngine.Offset,
                            //        positionY - GameEngine.Offset,
                            //        LargeTextureSize,
                            //        LargeTextureSize);

                            //    gameObjects.Add(new SpeedPowerUp(GameEngine.SpeedPowerUpTexture, rect));
                            //    break;
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
                            //case 'S':
                            //    rect = new Rectangle(
                            //        positionX - GameEngine.Offset,
                            //        positionY - GameEngine.Offset,
                            //        LargeTextureSize,
                            //        LargeTextureSize);

                            //    gameObjects.Add(new StrongTank(GameEngine.BasicTankTexture, rect));
                            //    break;
                            //case 'O':
                            //    rect = new Rectangle(
                            //        positionX - GameEngine.Offset,
                            //        positionY - GameEngine.Offset,
                            //        SmallTextureSize,
                            //        SmallTextureSize);

                            //    gameObjects.Add(new BossTank(GameEngine.PlayerTankTexture, rect));
                            //    break;
                            //case 'U':
                            //    rect = new Rectangle(
                            //        positionX - GameEngine.Offset,
                            //        positionY - GameEngine.Offset,
                            //        LargeTextureSize,
                            //        LargeTextureSize);

                            //    gameObjects.Add(new BasicBunker(GameEngine.BunkerTexture, rect));
                            //    break;
                            //case 'R':
                            //    rect = new Rectangle(
                            //        positionX - GameEngine.Offset,
                            //        positionY - GameEngine.Offset,
                            //        LargeTextureSize,
                            //        LargeTextureSize);

                            //    gameObjects.Add(new FortifiedBunker(GameEngine.BunkerTexture, rect));
                            //    break;
                            //case 'H':
                            //    rect = new Rectangle(
                            //        positionX - GameEngine.Offset,
                            //        positionY - GameEngine.Offset,
                            //        LargeTextureSize,
                            //        LargeTextureSize);

                            //    gameObjects.Add(new ShieldPowerUp(GameEngine.ShieldTexture, rect));
                            //    break;
                            //case 'A':
                            //    rect = new Rectangle(
                            //        positionX - GameEngine.Offset,
                            //        positionY - GameEngine.Offset,
                            //        LargeTextureSize,
                            //        LargeTextureSize);

                            //    gameObjects.Add(new ArmorConsumable(GameEngine.ArmorTexture, rect));
                            //    break;
                            //case 'E':
                            //    rect = new Rectangle(
                            //        positionX - GameEngine.Offset,
                            //        positionY - GameEngine.Offset,
                            //        LargeTextureSize,
                            //        LargeTextureSize);

                            //    gameObjects.Add(new HealthConsumable(GameEngine.HealthTexture, rect));
                            //    break;
                            //case 'L':
                            //    rect = new Rectangle(
                            //        positionX - GameEngine.Offset,
                            //        positionY - GameEngine.Offset,
                            //        LargeTextureSize,
                            //        LargeTextureSize);

                            //    gameObjects.Add(new SteelBarricade(GameEngine.SteelWallTexture, rect));
                            //    break;
                            case '\n':
                                positionY += LargeTextureSize;
                                positionX = LargeTextureSize;
                                break;
                        }

                        positionX += LargeTextureSize;
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
