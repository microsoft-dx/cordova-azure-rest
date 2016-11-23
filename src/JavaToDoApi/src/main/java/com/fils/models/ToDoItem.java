package com.fils.models;

import java.util.UUID;

/**
 * Created by radu on 16/11/2016.
 */
public class ToDoItem {
    private UUID id;
    private String text;
    private String address;
    private boolean done;

    public ToDoItem(){

    }

    public ToDoItem(String text, String address, boolean done){
        this.id = UUID.randomUUID();
        this.text = text;
        this.address = address;
        this.done = done;
    }

    public void UpdateToDo(ToDoItem item){
        this.setId(item.getId());
        this.setText(item.getText());
        this.setAddress(item.getAddress());
        this.setDone(item.isDone());
    }

    public UUID getId() {
        return id;
    }

    public void setId(UUID id) {
        this.id = id;
    }

    public String getText() {
        return text;
    }

    public void setText(String text) {
        this.text = text;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public boolean isDone() {
        return done;
    }

    public void setDone(boolean done) {
        this.done = done;
    }
}
