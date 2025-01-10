# Solitaire Elevens (C#)

## Overview

**Solitaire Elevens** is a single-player card game implemented in C#. The objective is to remove all cards from the board by:
1. Forming pairs of cards whose ranks add up to 11.
2. Forming a trio of King, Queen, and Jack (K-Q-J).

You win if you successfully clear the board (and effectively exhaust the deck). If you reach a state where no valid moves remain and cards are still on the board, the game is lost.

## Rules

1. **Starting the Game**  
   - A standard deck of 52 cards is shuffled.  
   - The first 9 cards are dealt face up onto the board.

2. **Valid Moves**  
   1. **Pairs Summing to 11**  
      - Remove two cards whose combined ranks equal 11.  
      - Rank values are typically assigned as:  
        - **Ace = 1**  
        - **2–10 = Face Value**  
        - **Jack = 11**  
        - **Queen = 12**  
        - **King = 13**  
      - For instance, a `6` and a `5` can be removed together (6 + 5 = 11).  
      - An `Ace` (1) can pair with a `10` to make 11, etc.

   2. **King-Queen-Jack Sets**  
      - Any King, Queen, and Jack can be removed as a set (suits don’t matter).

3. **Replacing Cards**  
   - When cards are removed, they are immediately replaced with new cards from the deck (if any are left), to maintain 9 face-up cards on the board.  
   - The deck count decreases accordingly.

4. **Winning / Losing**  
   - **Win**: Remove all cards from the board. If the deck is also exhausted, you’ve won the game.  
   - **Lose**: If no valid move (pair summing to 11 or K-Q-J set) is available and there are still cards on the board, the game ends in a loss.


## Quick Start

1. **Clone the Repository**
2. **Open the Project**
3. **Build and Run**

