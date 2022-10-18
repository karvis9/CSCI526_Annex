# %%
import seaborn as sns
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
%matplotlib inline

# %%
data = pd.read_csv(r"C:\Users\zerin\Downloads\Analytics(Responses).csv")

# %%


# %%


# %%
data


# %%

data.drop(data[data['Event'] == 'Level Cleared'].index, inplace=True)

# %%

data.drop(data[data['Event'] == 'Level failed'].index, inplace=True)


# %%

data

# %%

print(data)

# %%


# %%
sns.catplot(x="Category", hue="Event", kind="count", data=data)

# %%
data['Category'].value_counts().plot(kind='pie', autopct='%1.0f%%')


# %%
data['Category'].value_counts().plot(kind='bar')

# %%
data.loc[:, "Time Remaining"] = data["Time Remaining"].apply(lambda x: 120 - x)

# %%
print(data)

# %%
sns.barplot(x="Word Length", y="Time Remaining", data=data)
plt.xlabel("Word Length")
plt.ylabel("Time Elapsed")
plt.show()

# %%
sns.barplot(x="Category", y="Time Remaining", data=data)
plt.xlabel("Category")
plt.ylabel("Time Elapsed")
plt.show()

# %%
sns.barplot(x="Category", y="Score", data=data)
plt.xlabel("Category")
plt.ylabel("Score")
plt.show()

# %%
sns.barplot(x="Word Length", y="Score", data=data)
plt.xlabel("Word Length")
plt.ylabel("Score")
plt.show()

# %%
data = data.apply(lambda x: x.fillna(x.value_counts().index[0]))
print(data)

# %%
#data=data['Time Remaining'].fillna(int(data['Time Remaining'].mean()), inplace=True)
# print(data)

# %%
#data=data['Score'].fillna(int(data['Score'].mean()), inplace=True)
# print(data)

# %%
#data=data['Word Length'].fillna(int(data['Word Length'].mode()), inplace=True)
# print(data)

# %%
#data=data['Time Remaining'].fillna(int(data['Time Remaining'].mean()), inplace=True)
# print(data)

# %%
#time = 120- data['Time Remaining']
#print (time)

# %%
#data.loc[:, "Time Remaining"] = data["Time Remaining"].apply(lambda x: 120 - x)

# %%
# print(data)

# %%
#meanTime = data['Time Remaining'].mean()

# %%
X = np.array(data["Word Length"]).reshape(-1, 1)
Y = np.array(data["Time Remaining"]).reshape(-1, 1)
plt.scatter(X, Y, marker="+", color="green")
plt.xlabel("Word Length")
plt.ylabel("Time Elapsed")

# %%
X = np.array(data["Time Remaining"]).reshape(-1, 1)
Y = np.array(data["Score"]).reshape(-1, 1)
plt.scatter(X, Y, marker="+", color="green")
plt.xlabel("Time Remaining")
plt.ylabel("Score")


# %%
X = np.array(data["Time Remaining"]).reshape(-1, 1)
Y = np.array(data["Arrows Count"]).reshape(-1, 1)
plt.scatter(X, Y, marker="+", color="green")
plt.xlabel("Time Remaining")
plt.ylabel("Arrows Count")

# %%
categories = ['Movies', 'Animals', 'Places', 'Fruits']


# portion covered by each label

slices = [3, 7, 8, 6]


# color for each label

colors = ['r', 'y', 'g', 'b']


# plotting the pie chart

plt.pie(slices, labels=categories, colors=colors,

        startangle=90, shadow=True, explode=(0, 0, 0, 0),

        radius=1.7, autopct='%1.1f%%')


# plotting legend
# plt.legend()


# showing the plot
plt.show()


# %%
X = ['Movies', 'Places', 'Animals', 'Fruits']

success = [10, 20, 20, 40]

failure = [20, 30, 25, 30]


X_axis = np.arange(len(X))


plt.bar(X_axis - 0.2, success, 0.4, label='Success')

plt.bar(X_axis + 0.2, failure, 0.4, label='Failure')


plt.xticks(X_axis, X)

plt.xlabel("Categories")

plt.ylabel("Number of Players")

plt.title("Outcome")
plt.legend()
plt.show()

# %%


# %% [markdown]
#

# %%
dataA = pd.read_csv(r"C:\Users\zerin\Documents\gameData1.csv")

# %%
dataA


# %%


# %%
dataA

# %%
sns.catplot(x="Levels", hue="Event", kind="count", data=dataA)

# %%
dataA.drop(dataA[dataA['Event'] == 'Level failed'].index, inplace=True)

# %%
dataA.drop(dataA[dataA['Event'] == 'Char Revealed 1'].index, inplace=True)
dataA.drop(dataA[dataA['Event'] == 'Char Revealed 2'].index, inplace=True)
dataA.drop(dataA[dataA['Event'] == 'Char Revealed 3'].index, inplace=True)
dataA.drop(dataA[dataA['Event'] == 'Char Revealed 4'].index, inplace=True)
dataA.drop(dataA[dataA['Event'] == 'Char Revealed 5'].index, inplace=True)
dataA.drop(dataA[dataA['Event'] == 'Char Revealed 6'].index, inplace=True)
dataA.drop(dataA[dataA['Event'] == 'Char Revealed 7'].index, inplace=True)
dataA.drop(dataA[dataA['Event'] == 'Char Revealed 8'].index, inplace=True)
dataA.drop(dataA[dataA['Event'] == 'Char Revealed 9'].index, inplace=True)
dataA.drop(dataA[dataA['Event'] == 'Char Revealed 10'].index, inplace=True)
dataA.drop(dataA[dataA['Event'] == 'Enemey Touched'].index, inplace=True)
dataA.drop(dataA[dataA['Event'] == 'Enemey Hit'].index, inplace=True)
dataA.drop(dataA[dataA['Event'] == 'Power up : 2x'].index, inplace=True)
dataA.drop(dataA[dataA['Event'] == 'Power up: +5'].index, inplace=True)
dataA.drop(dataA[dataA['Event'] == 'Bomb hit'].index, inplace=True)

# %%
dataA


# %%
sns.catplot(x="Levels", hue="Event", kind="count", data=dataA)

# %%
sns.catplot(x="Levels", hue="Category", kind="count", data=dataA)

# %%
dataA.loc[:, "Time Remaining"] = dataA["Time Remaining"].apply(
    lambda x: 120 - x)


# %%
dataA.drop(dataA[dataA['Levels'] == '0'].index, inplace=True)

# %%


# %%
sns.barplot(x="Levels", y="Time Remaining", data=dataA)
plt.xlabel("Levels")
plt.ylabel("Time Elapsed")
plt.show()

# %%
