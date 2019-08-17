using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    // Time since last gravity tick
    private float lastFall = 0;

    public bool IsValidGridPos()
    {
        bool isValid = true;
        foreach (Transform child in transform) {
            Vector2 pos = Playfield.roundVect2(child.position);
            
            if (!Playfield.insideBorder(pos))
            {
                isValid = false;
            }

            if (isValid && Playfield.grid[(int)pos.x, (int)pos.y] != null &&
                Playfield.grid[(int)pos.x, (int)pos.y].parent != transform)
                isValid = false;
            Debug.Log(isValid);
        }
        
        return isValid;
    }
    void updateGrid()
    {
        for(int y = 0; y < Playfield.h; ++y)
        {
            for(int x = 0; x < Playfield.w; ++x)
            {
                if (Playfield.grid[x, y] != null)
                    if (Playfield.grid[x, y].parent == transform)
                        Playfield.grid[x, y] = null;
            }
            foreach(Transform child in transform)
            {
                Vector2 v = Playfield.roundVect2(child.position);
                Playfield.grid[(int)v.x, (int)v.y] = child;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!IsValidGridPos())
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (IsValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(1, 0, 0);
            Debug.Log(transform.position);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);

            if (IsValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(1, 0, 0);
            Debug.Log(transform.position);
        }
        // Rotate
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);

            // See if valid
            if (IsValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.Rotate(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) ||
             Time.time - lastFall >= 1)
        {
            // Modify position
            transform.position += new Vector3(0, -1, 0);

            // See if valid
            if (IsValidGridPos())
            {
                // It's valid. Update grid.
                updateGrid();
            }
            else
            {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);

                // Clear filled horizontal lines
                int delta = Playfield.deleteFullRows();
                GameController.gc.CalculateCount(delta);
                // Spawn next Group
                FindObjectOfType<Spawner>().Spawn();

                // Disable script
                enabled = false;
            }

            lastFall = Time.time;
        }
    }
}
