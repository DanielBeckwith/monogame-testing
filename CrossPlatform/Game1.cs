using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrossPlatform;
public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        List<string> contentNames = new List<string>
        {
            "NormalUnmodifiedFileName",
            "Some strings (should also work)",
            "😄", // emoji
            "𠂇" // rare character from the Unified Ideographs Extension B
        };

        List<string> contentNamesThatFail = new List<string>();
        List<Exception> exceptions = new List<Exception>();

        foreach (string contentName in contentNames)
        {
            try
            {
                var values = Content.Load<List<string>>(contentName);
                Debug.WriteLine($"Successfully loaded values in '{contentName}'");
                foreach (var value in values)
                {
                    Debug.WriteLine($"Value: {value}");
                }
                Debug.WriteLine($"Values in '{contentName}' complete.\n");
            }
            catch (Exception ex)
            {
                contentNamesThatFail.Add(contentName);
                exceptions.Add(ex);
            }
        }

        if (exceptions.Count > 0)
        {
            throw new AggregateException($"The following content names failed: '{string.Join("', '", contentNamesThatFail)}'. See the inner exceptions for more information.", exceptions);
        }
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
