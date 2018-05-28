## RoverMotionControl

Problem Statement:

You have a Rover that follows commands to move around on a plane surface. Locations on the surface are identified with an X-Y coordinate pair, and the Rover can face any one of 4 directions - North, South, East, West.

Commands are a sequence of characters - or a String - of the form
"LRLLMMMMLMMR" etc. So, given an initial location+direction combination (X, Y, D), and a command string C, you would want the Rover to process the command C and respond with an updated location+direction (X', Y', D').

Eg:

(0, 0, N) -- "MMM" -- (0, 3, N)

(0, 1, E) -- "MML" -- (2, 1, N)

(10, 5, N) -- "MMLMRMML" -- (?, ?, ?)


----

