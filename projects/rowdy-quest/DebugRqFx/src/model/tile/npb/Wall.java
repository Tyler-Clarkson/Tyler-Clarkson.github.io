package model.tile.npb;

import model.texture.Texture;
import model.tile.Tile;
/**
 * 
 * @author Brandon Black
 *
 */

public class Wall extends Tile{

	public Wall(int id) {
		super(Texture.wall, id, null);
		// TODO Auto-generated constructor stub
	}
	
	/*@Override
	public boolean isSolid() {
		return true;
	}*/
	
	public boolean isSolidRight() {
		return true;
	}
	public boolean isSolidLeft() {
		return true;
	}
	public boolean isSolidTop() {
		return true;
	}
	public boolean isSolidBottom() {
		return true;
	}

}
