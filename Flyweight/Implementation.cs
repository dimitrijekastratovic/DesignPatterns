using System;
namespace Flyweight
{
    /// <summary>
    /// Flyweight
    /// </summary>
    public interface ICharacter
    {
        void Draw(string font, int fontSize);
    }

    public class CharacterA : ICharacter
    {
        private char _actualCharacter = 'a';
        private string _font = string.Empty;
        private int _fontSize;

        public void Draw(string font, int fontSize)
        {
            _font = font;
            _fontSize = fontSize;
            Console.WriteLine($"Drawing character {_actualCharacter}, {_font} {_fontSize}");
        }
    }

    public class CharacterB : ICharacter
    {
        private char _actualCharacter = 'b';
        private string _font = string.Empty;
        private int _fontSize;

        public void Draw(string font, int fontSize)
        {
            _font = font;
            _fontSize = fontSize;
            Console.WriteLine($"Drawing character {_actualCharacter}, {_font} {_fontSize}");
        }
    }

    public class Paragraph : ICharacter
    {
        private int _location;
        private List<ICharacter> _characters = new();

        public Paragraph(List<ICharacter> characters, int location)
        {
            _location = location;
            _characters = characters;
        }

        public void Draw(string font, int fontSize)
        {
            Console.WriteLine($"Drawing paragraph at location: {_location}.");
            foreach(var character in _characters)
            {
                character.Draw(font, fontSize);
            }
        }
    }

    public class CharacterFactory
    {
        private readonly Dictionary<char, ICharacter> _characters = new();

        public ICharacter? GetCharacter(char characterId)
        {
            if(_characters.ContainsKey(characterId))
            {
                Console.WriteLine("Character reuse.");
                return _characters[characterId];
            }

            Console.WriteLine("Character creation.");
            var newChar = characterId switch
            {
                'a' => _characters[characterId] = new CharacterA(),
                'b' => _characters[characterId] = new CharacterB(),
                _ => null
            };

            return newChar;
        }

        public ICharacter CreateParagraph(List<ICharacter> characters, int location)
        {
            return new Paragraph(characters, location);
        }
    }
}



