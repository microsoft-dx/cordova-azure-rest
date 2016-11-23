package com.fils.dal;

import com.fils.models.ToDoItem;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

/**
 * Created by radu on 16/11/2016.
 */
public class ToDoRepository {
    private List<ToDoItem> _toDoList;

    public ToDoRepository(){
        _toDoList = new ArrayList<>();

        _toDoList.add(new ToDoItem("Get groceries", "43.465187,-80.522372", false));
        _toDoList.add(new ToDoItem("Walk the dog", "43.465187,-80.522372", false));
        _toDoList.add(new ToDoItem("Take the car to the shop", "43.465187,-80.522372", false));
    }

    public List<ToDoItem> getToDoItems(){
        return _toDoList;
    }

    public ToDoItem getById(UUID id){
        for(ToDoItem t : _toDoList)
            if(t.getId().compareTo(id) == 0)
                return t;

        return null;
    }

    public void createToDoItem(ToDoItem toDo){
        _toDoList.add(toDo);
    }

    public void deleteToDoItem(UUID id){

        ToDoItem toDoToDelete = null;

        for(ToDoItem t : _toDoList){
            if(t.getId().compareTo(id) == 0)
                toDoToDelete = t;
        }

        if(toDoToDelete != null)
            _toDoList.remove(toDoToDelete);
    }

    public void updateToDoItem(ToDoItem toDo){

        ToDoItem toDoToUpdate = null;

        for(ToDoItem t : _toDoList){
            if(t.getId().compareTo(toDo.getId()) == 0)
                toDoToUpdate = t;
        }

        if(toDoToUpdate != null)
            toDoToUpdate.UpdateToDo(toDo);
    }
}
