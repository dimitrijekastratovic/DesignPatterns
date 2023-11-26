using Flyweight;
Console.Title = "Flyweight Pattern";

//Description:
//    The goal of Flyweight Pattern is to use sharing to support large number of fine-grained objects efficiently.
//    It does that by sharing parts of the state between these objects instead of keeping all that state in all of the objects.

//Questions before implementing Flyweight Pattern:
//  1. Does application use a large number of objects?
//  2. Are storage costs high because of the large amount of objects?
//  3. Can most of the objects state be made extrinsic?
//  4. If you remove extrinsic state,can large group of objects be replaced by relatively few shared objects?
//  5. Does application require object identity?
//Implement only if answers to all of these are true.


var someChars = "aabb";
var characterFactory = new CharacterFactory();

var charObject = characterFactory.GetCharacter(someChars[0]);
charObject?.Draw("Font1", 12);

charObject = characterFactory.GetCharacter(someChars[1]);
charObject?.Draw("Font2", 12);

charObject = characterFactory.GetCharacter(someChars[2]);
charObject?.Draw("Font3", 12);

charObject = characterFactory.GetCharacter(someChars[3]);
charObject?.Draw("Font4", 12);

var paragraph = characterFactory.CreateParagraph(new List<ICharacter>() { charObject }, 1);
paragraph.Draw("Font5", 14);

Console.ReadKey();
