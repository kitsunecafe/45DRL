/*
- Access to the map is provided by an "ICellGrid" implementation, which has two methods:
    bool IsWall(int x, int y) - returns true if the cell is a wall
    void SetLight(int x, int y, float distanceSquared) - lights up the specified cell
  and two properties:
    int xDim, yDim - grid dimensions in the X and Y directions
  Coordinates are range-checked, so the methods will only be called with valid values.
*/

namespace JuniperJackal {
	public interface ICellGrid
	{
		int xDim { get; }
		int yDim { get; }

		bool IsWall(int x, int y);
		void SetLight(int x, int y, float distanceSquared);
	}
}