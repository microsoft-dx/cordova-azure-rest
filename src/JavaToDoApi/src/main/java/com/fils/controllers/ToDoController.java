package com.fils.controllers;

import com.fils.dal.ToDoRepository;
import com.fils.models.ToDoItem;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.UUID;

/**
 * Created by radu on 22/11/2016.
 */

@RestController
public class ToDoController {

    private ToDoRepository _todoRepository = new ToDoRepository();

    @RequestMapping(value = "/toDo", method = RequestMethod.GET)
    @CrossOrigin
    public List<ToDoItem> getAll(){
        return _todoRepository.getToDoItems();
    }

    @RequestMapping(value = "/toDo/{id}", method = RequestMethod.GET)
    @CrossOrigin
    public ToDoItem getById(@PathVariable("id") UUID id){
        return _todoRepository.getById(id);
    }

    @RequestMapping(value = "/toDo", method = RequestMethod.POST)
    @CrossOrigin
    public ToDoItem create(@RequestBody ToDoItem item){
        _todoRepository.createToDoItem(item);

        return item;
    }

    @RequestMapping(value = "/toDo", method = RequestMethod.PUT)
    @CrossOrigin
    public ToDoItem update(@RequestBody ToDoItem item){
        _todoRepository.updateToDoItem(item);

        return item;
    }

    @RequestMapping(value = "/toDo/{id}", method = RequestMethod.DELETE)
    @CrossOrigin
    public ResponseEntity<HttpStatus> delete(@PathVariable UUID id){
        _todoRepository.deleteToDoItem(id);

        return new ResponseEntity(HttpStatus.OK);
    }

}
