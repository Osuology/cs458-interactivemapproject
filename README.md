# cs458-project
CS 458 Project - Farming Game

## How to use GIT CLI (command line interface) with this repository
First use ``git clone https://github.com/Osuology/cs458-project`` to clone the project. If you've already cloned it, you can use ``git pull`` to update.

In ordor to submit a pull request, you must use a branch. You should create a branch based on the issue you are working on. It's often better to create small branches instead of large ones to prevent merge conflicts from being too large.
You can create a branch using ``git branch <name>`` where <name> is the name you want for the branch. Once you do this, you want to swap to the new branch with ``git checkout <name>``.
Any changes made from this point forth will only apply to this branch. If you save a change in a branch, and then ``git checkout main``, the changes will be gone until you checkout back to the branch you made those changes in.
When you commit changes, it's only made to t hat branch. Then you can use ``git push origin`` to push your branch to the main repository. (By the way, I determined using forks was unnecessary, and was legacy, my original thoughts on this were incorrect. You can PR to the main repo from a fork as well though! Feel free to use a fork to experiment with git.)

### Pull Request (PR)
When you submit a pull request, you are requesting to merge a branch (whether on your fork or not) with the main branch. For this project, you always want to have a separate branch to PR with the main branch on the repository.
Once you do this, your pull request is submitted! 

If you want to test this out, I've intentionally made two typos in this paragraph that you can fix (each person should fix one typo! Then the last person can delete this last message for their PR (pull request)). Remember to use a separate branch (even just for fixing a typo).

## How to use GIT Tortoise with this repository
First of all, I personally don't use this, but it is a lot more clear about what's happening. However, there's a couple unique functionalities that are rarely useful that aren't present. It doesn't matter which one you use really, so pick by your own preference.
You can right click in a folder to see all the options with GIT Tortoise, you want to use Git Clone to clone the repository. The URL is ``https://github.com/Osuology/cs458-project``.
Once again, no need to use a fork, it's easier to just make branches on the main repo. You can use Tortoise to create a branch with TortoiseGit->Create Branch... You can tell it to base it off either the current branch you are on (HEAD), or pick a specific one. Be sure to tell it to switch to this branch you're creating, unless you don't want that.
You can also checkout at any moment with TortoiseGit->Switch/Checkout...
Then, you will use Git Commit -> "Branch name" to commit changes (make sure you checkmark each file you added in the GUI to add them, or you can add them manually with TortoiseGit->Add...).

Read the PR section from the GIT CLI section for the rest of the instructions, these are the exact same.
