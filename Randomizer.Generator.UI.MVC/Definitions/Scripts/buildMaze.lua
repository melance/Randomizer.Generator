-- x = width
-- y = height
-- maze is a two dimensional array of objects with the properties North, East, South, and West which are all booleans that determine if a wall exists in that direction for that cell
local function buildMazeInternal(x,y,maze)

    local stack = {}
    local directions = {'North','East','South','West'}

    table.insert(stack,{x=x,y=y})

	height = tonumber(height)
	width = tonumber(width)
	
	for i = 1,width do
		maze[i] = {}		
	end
	
    while #stack > 0 do
        local index = 1
        local nextX = x
        local nextY = y
        local braid = false 

        for i = #directions, 2, -1 do -- backwards
            local r = rnd(1,i) -- select a random number between 1 and i
            directions[i], directions[r] = directions[r], directions[i] -- swap the randomly selected item to position i
        end

        while index <= #directions and nextX == x and nextY == y do
            if directions[index] == 'North' and 
			   y > 1 and 
			   not maze[y-1][x] ~= nil and
			   not maze[y-1][x].Visited then
                maze[y][x].North = true
                maze[y-1][x].South = true
                nextY = y-1
            elseif directions[index] == 'East' and 
			   x < width and 
			   not maze[y][x+1] ~= nil and
			   not maze[y][x+1].Visited then
                maze[y][x].East = true
                maze[y][x+1].West = true
                nextX = x+1
            elseif directions[index] == 'South' and 
			   y < height and 
			   not maze[y+1][x] ~= nil and
			   not maze[y+1][x].Visited then
                maze[y][x].South = true
                maze[y+1][x].North = true
                nextY = y+1
            elseif directions[index] == 'West' and 
			   x > 1 and 
			   not maze[y][x-1] ~= nil and
			   not maze[y][x-1].Visited then
                maze[y][x].West = true
                maze[y][x-1].East = true
                nextX = x-1
            else
                index = index + 1
            end
        end

        if nextX ~= x or nextY ~= y then
            x = nextX
            y = nextY
            maze[y][x].Visited = true
            table.insert(stack,{x=x,y=y})
        else    
            x = stack[#stack].x
            y = stack[#stack].y
            table.remove(stack)
        end
    end
end

local maze = {}
local borderStyle = "1px solid black"

buildMazeInternal(1,1,maze)

print("<table>")

for x = 1, #maze do
	print ("<tr>")
	for y = 1, #maze[x] do
		print ("<td style='")
		printif(maze[x][y].North, "border-top:" .. borderStyle .. "; ")
		printif(maze[x][y].East, "border-right" .. borderStyle .. "; ")
		printif(maze[x][y].South, "border-bottom:" .. borderStyle .. "; ")
		printif (maze[x][y].West, "border-left:" .. borderStyle .. "; ")
		print ("'>&nbsp;</td>")
	end
	print ("</tr>")
end

print ("</table>")
