// See https://aka.ms/new-console-template for more information

List<Valve> valves = new List<Valve>();

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

Valve currentValve;
foreach (string inputLine in input)
{
	string[] halves = inputLine.Split(";");
	string[] firstHalf = halves[0].Split(" ");

	currentValve = valves.FirstOrDefault(v => v.Name == firstHalf[1]);
	if (currentValve == null)
	{
		currentValve = new Valve();
	}

	currentValve.Name = firstHalf[1];
	currentValve.FlowRate = int.Parse(firstHalf[4].Replace("rate=", string.Empty));
	string secondHalf = halves[1];
	secondHalf = secondHalf.Replace(" tunnels lead to valves", string.Empty)
		.Replace(" tunnel leads to valve", string.Empty).Replace(" ", string.Empty);
	string[] linkedValves = secondHalf.Split(",");
	foreach (string valveName in linkedValves)
	{
		Valve linkedValve = valves.FirstOrDefault(v => v.Name == valveName);
		if (linkedValve == null)
		{
			linkedValve = new Valve() {Name = valveName};
			valves.Add(linkedValve);
		}
		currentValve.LinkedValves.Add(linkedValve);
	}

	if (!valves.Contains(currentValve))
	{
		valves.Add(currentValve);
	}
}

foreach (Valve valve in valves.OrderBy(v => v.Name))
{
	Console.WriteLine(valve.Name);
}




Console.ReadLine();



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