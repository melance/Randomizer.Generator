using System;
using System.Text;
using System.Collections.Generic;

class Cell
{
	public Boolean Visited { get; set; }
	public Boolean North { get; set; }
	public Boolean East { get; set; }
	public Boolean South { get; set; }
	public Boolean West { get; set; }
}

private List<Char> Directions = new()
{
	'N',
	'E',
	'S',
	'W',
};
private readonly Random random = new();

public Dictionary<String, Object> Parameters { get; set; }

public String Generate()
{		
	var width = (Int32)Parameters["Width"];
	var height = (Int32)Parameters["Height"];
	var maze = new Cell[width, height];
	var remaining = width * height;

	InitializeMaze(maze);

	var currentX = random.Next(0, width - 1);
	var currentY = random.Next(0, height - 1);

	maze[currentX, currentY].Visited = true;

	while (remaining > 0)
	{
		Shuffle(Directions);
		var found = false;
		var i = 0;

		Char name;
		Int32 deltaX = 0;
		Int32 deltaY = 0;
		Int32 newCellX = 0;
		Int32 newCellY = 0;

		do
		{
			name = Directions[i];
			switch (name)
			{
				case 'N':
					deltaX = 0;
					deltaY = -1;
					break;
				case 'E':
					deltaX = 1;
					deltaY = 0;
					break;
				case 'S':
					deltaX = 0;
					deltaY = 1;
					break;
				case 'W':
					deltaX = -1;
					deltaY = 0;
					break;
			}
			newCellX = currentX + deltaX;
			newCellY = currentY + deltaY;

			if (newCellX >= 0 && newCellY >= 0 && newCellX < width && newCellY < height)
				found = true;
			else
				i++;

		} while (i < Directions.Count && !found);

		if (!maze[newCellX, newCellY].Visited)
		{
			switch (name)
			{
				case 'N':
					maze[currentX, currentY].North = true;
					break;
				case 'E':
					maze[currentX, currentY].East = true;
					break;
				case 'S':
					maze[currentX, currentY].South = true;
					break;
				case 'W':
					maze[currentX, currentY].West = true;
					break;
			}
			remaining--;
		}

		currentX = newCellX;
		currentY = newCellY;
	}

	return FormatMaze(maze);
}

private void Shuffle<T>(IList<T> list)
{
	int n = list.Count;
	while (n > 1)
	{
		n--;
		int k = random.Next(n + 1);
		T value = list[k];
		list[k] = list[n];
		list[n] = value;
	}
}

private static void InitializeMaze(Cell[,] maze)
{
	for (var y = 0; y < maze.GetLength(1); y++)
	{
		for (var x = 0; x < maze.GetLength(0); x++)
		{
			maze[x, y] = new Cell();
		}
	}
}

private static String FormatMaze(Cell[,] maze)
{
	var result = new StringBuilder();
	var borderStyle = "1px solid black;";

	result.AppendLine("<table>");
	for (var y = 0; y < maze.GetLength(1); y++)
	{
		result.AppendLine("<tr>");
		for (var x = 0; x < maze.GetLength(0); x++)
		{
			result.Append("<td style='");
			if (maze[x, y].North) result.Append($"border-top: {borderStyle}");
			if (maze[x, y].East) result.Append($"border-right: {borderStyle}");
			if (maze[x, y].South) result.Append($"border-bottom: {borderStyle}");
			if (maze[x, y].West) result.Append($"border-left: {borderStyle}");
			result.Append(">&nbsp;</td>");
		}
		result.AppendLine("</tr>");
	}
	result.AppendLine("</table>");
	return result.ToString();
}
