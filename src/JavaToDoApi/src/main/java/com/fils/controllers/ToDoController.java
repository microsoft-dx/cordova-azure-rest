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



}
