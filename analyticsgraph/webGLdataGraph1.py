#!/usr/bin/env python
# coding: utf-8

# In[243]:


import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
get_ipython().run_line_magic('matplotlib', 'inline')
import seaborn as sns


# In[244]:


data=pd.read_csv(r"C:\Users\zerin\Downloads\Analytics(Responses).csv")


# In[ ]:





# In[ ]:





# In[245]:


data


# In[246]:



data.drop(data[data['Event'] == 'Level Cleared'].index, inplace = True)


# In[248]:



data.drop(data[data['Event'] == 'Level failed'].index, inplace = True)


# In[249]:



data


# In[250]:



print(data)


# In[262]:





# In[263]:


sns.catplot(x = "Category", hue = "Event", kind = "count", data = data)


# In[264]:


data['Category'].value_counts().plot(kind='pie',autopct='%1.0f%%')


# In[265]:


data['Category'].value_counts().plot(kind='bar')


# In[255]:


data.loc[:, "Time Remaining"] = data["Time Remaining"].apply(lambda x: 120 - x)


# In[256]:


print(data)


# In[257]:


sns.barplot(x="Word Length",y="Time Remaining",data=data)
plt.xlabel("Word Length")
plt.ylabel("Time Elapsed")
plt.show()


# In[258]:


sns.barplot(x="Category",y="Time Remaining",data=data)
plt.xlabel("Category")
plt.ylabel("Time Elapsed")
plt.show()


# In[259]:


sns.barplot(x="Category",y="Score",data=data)
plt.xlabel("Category")
plt.ylabel("Score")
plt.show()


# In[261]:


sns.barplot(x="Word Length",y="Score",data=data)
plt.xlabel("Word Length")
plt.ylabel("Score")
plt.show()


# In[161]:


data=data.apply(lambda x: x.fillna(x.value_counts().index[0]))
print(data)


# In[53]:


#data=data['Time Remaining'].fillna(int(data['Time Remaining'].mean()), inplace=True)
#print(data)


# In[54]:


#data=data['Score'].fillna(int(data['Score'].mean()), inplace=True)
#print(data)


# In[35]:


#data=data['Word Length'].fillna(int(data['Word Length'].mode()), inplace=True)
#print(data)


# In[36]:


#data=data['Time Remaining'].fillna(int(data['Time Remaining'].mean()), inplace=True)
#print(data)


# In[37]:


#time = 120- data['Time Remaining']
#print (time)


# In[162]:


#data.loc[:, "Time Remaining"] = data["Time Remaining"].apply(lambda x: 120 - x)


# In[163]:


#print(data)


# In[39]:


#meanTime = data['Time Remaining'].mean()


# In[160]:


X=np.array(data["Word Length"]).reshape(-1,1)
Y=np.array(data["Time Remaining"]).reshape(-1,1)
plt.scatter(X,Y, marker="+",color="green")
plt.xlabel("Word Length")
plt.ylabel("Time Elapsed")


# In[61]:


X=np.array(data["Time Remaining"]).reshape(-1,1)
Y=np.array(data["Score"]).reshape(-1,1)
plt.scatter(X,Y, marker="+",color="green")
plt.xlabel("Time Remaining")
plt.ylabel("Score")


# In[62]:


X=np.array(data["Time Remaining"]).reshape(-1,1)
Y=np.array(data["Arrows Count"]).reshape(-1,1)
plt.scatter(X,Y, marker="+",color="green")
plt.xlabel("Time Remaining")
plt.ylabel("Arrows Count")


# In[43]:


categories = ['Movies', 'Animals', 'Places', 'Fruits'] 

  
# portion covered by each label 

slices = [3, 7, 8, 6] 

  
# color for each label 

colors = ['r', 'y', 'g', 'b'] 

  
# plotting the pie chart 

plt.pie(slices, labels = categories, colors=colors,  

        startangle=90, shadow = True, explode = (0, 0, 0, 0), 

        radius = 1.7,autopct = '%1.1f%%')

  
# plotting legend 
#plt.legend() 

  
# showing the plot 
plt.show() 
 


# In[44]:


X = ['Movies','Places','Animals','Fruits'] 

success = [10,20,20,40] 

failure = [20,30,25,30] 

  

X_axis = np.arange(len(X)) 

  

plt.bar(X_axis - 0.2, success, 0.4, label = 'Success') 

plt.bar(X_axis + 0.2, failure, 0.4, label = 'Failure') 

  
plt.xticks(X_axis, X) 

plt.xlabel("Categories") 

plt.ylabel("Number of Players") 

plt.title("Outcome") 
plt.legend() 
plt.show() 


# In[93]:





# In[ ]:




