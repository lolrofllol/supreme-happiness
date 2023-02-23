using ASK;

//var inputX = new List<string>() { "0", "1", "0101" };
//var inputY = new List<string>() { "010", "101", "01" };

var inputX = new List<string>() { "001", "01", "01", "10" };
var inputY = new List<string>() { "0", "011", "101" ,"001"};

var pcp = new PCP();
var result = pcp.Run(inputX, inputY);