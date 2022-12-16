// See https://aka.ms/new-console-template for more information

List<string> input = new List<string>
{
	"Valve AA has flow rate=0; tunnels lead to valves DD, II, BB",
	"Valve BB has flow rate=13; tunnels lead to valves CC, AA",
	"Valve CC has flow rate=2; tunnels lead to valves DD, BB",
	"Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE",
	"Valve EE has flow rate=3; tunnels lead to valves FF, DD",
	"Valve FF has flow rate=0; tunnels lead to valves EE, GG",
	"Valve GG has flow rate=0; tunnels lead to valves FF, HH",
	"Valve HH has flow rate=22; tunnel leads to valve GG",
	"Valve II has flow rate=0; tunnels lead to valves AA, JJ",
	"Valve JJ has flow rate=21; tunnel leads to valve II"
};

Valve AA = new Valve();
Valve BB = new Valve();
Valve CC = new Valve();
Valve DD = new Valve();
Valve EE = new Valve();
Valve FF = new Valve();
Valve GG = new Valve();
Valve HH = new Valve();
Valve II = new Valve();
Valve JJ = new Valve();

Valve currentValve;
foreach (string inputLine in input)
{
	string[] halves = inputLine.Split(";");
	string[] firstHalf = halves[0].Split(" ");
	currentValve = FindValve(firstHalf[1]);
	currentValve.Name = firstHalf[1];
	currentValve.FlowRate = int.Parse(firstHalf[4].Replace("rate=", string.Empty));
	string secondHalf = halves[1];
	secondHalf = secondHalf.Replace(" tunnels lead to valves", string.Empty)
		.Replace(" tunnels lead to valve", string.Empty).Replace(" ", string.Empty);
	string[] linkedValves = secondHalf.Split(",");
	foreach (string valveName in linkedValves)
	{
		currentValve.LinkedValves.Add(FindValve(valveName));
	}
}

Valve currentLocation = FindValve("AA");



Console.ReadLine();

Valve FindValve(string name)
{
	switch (name)
	{
		case "AA":
			return AA;
		case "BB":
			return BB;
		case "CC":
			return CC;
		case "DD":
			return DD;
		case "EE":
			return EE;
		case "FF":
			return FF;
		case "GG":
			return GG;
		case "HH":
			return HH;
		case "II":
			return II;
		case "JJ":
			return JJ;
	}

	return null;
}

public class Valve
{
	public Valve()
	{
		LinkedValves = new List<Valve>();
	}
	public string Name { get; set; }
	public int FlowRate { get; set; }
	public bool Open { get; set; }

	public List<Valve> LinkedValves { get; set; }
}