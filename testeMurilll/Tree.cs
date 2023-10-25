using System.Collections.Generic;

public class Node
{
    public List<Node> Children { get; set; } = new();
    public bool Expanded { get; set; } = false;
    public bool YouPlays { get; set; } = true;

    
}