# CSCI526_Annex
Github Repo for Games Course (Team Annex) Tuesday Class.

Core idea : Pocket tanks war with word guessing/Hangman.

Game Concept: This is a game at the intersection of concepts derived from Word Guessing or the game Hangman (similar to the wheel of fortune TV show) and War-Action games. For guessing the words, the user can choose a category from given options. The end goal of the user is to guess a word at each level in the shortest amount of time. 
 
Gameplay: Initially the categories are displayed for the player to choose from. After entering a category, words from that particular category will be given for the user to guess. And the way that the user will guess the words, is by shooting letters which will show up in the form of dynamically moving bubbles. The user is given a bow and an arrow, which he can shoot using a projectile angle to hit the bubbles. When a correct bubble is hit, ie, when a letter which exists in the current word is hit by the player's arrow, it will fill up in the blanks for the word on the top of the screen. In this way, the player can guess the other letters, and try to hit those from the letter bubbles. There are multiple levels in this game. Based on the accuracy of the player, a backend algorithm generates a certain score. If the player guesses the word correctly he/she gets points accordingly (and also bonus points for getting it right in one attempt and not taking multiple attempts on the target plus the time saved.) If the guess is incorrect, then the player resumes the attempts. The level ends when either the time runs out or the whole word is guessed correctly. 
 
Variations of the Game: We have multiple upgrades/ variations in mind while designing the game. We can have a single target or a target similar to the darts board where there are multiple points for hitting different sections of the target (See screenshots attached). Based on this the clues are unboxed. For example, if the player hits a hard section, then they get more favorable clues and if the player hits an easy section of the target, they get less favorable clues. The way the clues are generated are based on the algorithm we have on the backend. Some other modifications include having picture clues rather than just characters being unboxed like in wheel of fortune, or having synonyms of words like codenames for future levels to make them more challenging.


Backend Algorithm :
For generating the corpus of words, we plan on scraping the English dictionary for a word set, typically having 6-7 or more alphabets per word. Once we have a corpus, we would have a recommendation model, which based on the target accuracy of the user, gives the alphabets to be revealed to the player. The initial idea is to assign frequency scores to the alphabets based on their usage from a corpus, and select those alphabets to be revealed which add up to the normalized [0-1] player’s hit/aim score for a particular round. This hit score can be calculated using a number of parameters such as the target hit or not, the proximity to the target, the velocity with which it hit the target, the damage done to the target scope and a number of other params etc. We can break ties by revealing the set of alphabets which have a bigger sample size.
 
In the below diagrams, we can see a rough sketch, where the player is trying to hit the target with a weapon and based on the hit score, the clues of the word get unboxed.

GDD : https://docs.google.com/document/d/1HRto0uA2G6PbvSqq6L8PJw33nUCTbYQKOtgvwyj9xgM/edit

