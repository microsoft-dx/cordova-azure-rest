package com.fils.controllers;

import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by radu on 16/11/2016.
 */

@RestController
public class HomeController {

    @RequestMapping("/")
    @CrossOrigin
    public String index(){
        return "Hello, Universe!";
    }
}
