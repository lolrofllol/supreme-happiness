using ASK;

//var inputX = new List<string>() { "0", "1", "0101" };
//var inputY = new List<string>() { "010", "101", "01" };

var inputX = new List<string>() { "001", "01", "01", "10" };
var inputY = new List<string>() { "0", "011", "101", "001" };

var pcp = new PCP();
pcp.RunDepthSearch(inputX, inputY, 10);
//var result = pcp.Run(inputX, inputY);
//var result = pcp.RunWithTree(inputX, inputY, depth: 50);

//int inputLength = inputX.Count;

//for (int x = 0; x < 100; x++)
//{
//    Console.WriteLine($"creating depth layer {x}");

//    var lastFilePath = $"D:\\Development\\GitHub\\supreme-happiness\\ASK\\ASK\\pcp-{x}.txt";
//    var filePath = $"D:\\Development\\GitHub\\supreme-happiness\\ASK\\ASK\\pcp-{x + 1}.txt";
//    var file = File.Create(filePath);
//    file.Close();

//    var tempLastWordsX = new List<string>();
//    var tempLastWordsY = new List<string>();

//    using StreamWriter streamWriter = new(filePath, append: true);

//    if (File.Exists(lastFilePath))
//    {
//        using StreamReader streamReader = new(lastFilePath);

//        while ((line)
//        {

//        }
//        streamReader.ReadLine();

//        for (int j = 0; j < lastWordsX.Count; j++)
//        {
//            for (int i = 0; i < inputLength; i++)
//            {
//                var wordX = lastWordsX[j] + inputX[i];
//                var wordY = lastWordsY[j] + inputY[i];

//                tempLastWordsX.Add(wordX);
//                tempLastWordsY.Add(wordY);

//                await streamWriter.WriteLineAsync(wordX);
//                await streamWriter.WriteLineAsync(wordY);
//            }
//        }

//        streamWriter.Close();
//    }
//}