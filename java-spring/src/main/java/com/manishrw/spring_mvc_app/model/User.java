package com.manishrw.spring_mvc_app.model;

import jakarta.persistence.*;
import lombok.NonNull;

@Entity
@Table(name = "Users")
public class User {

    @Id
    @NonNull private Long id;

    @Column(name = "Name")
    @NonNull private String name;

    @Column(name = "Email")
    @NonNull private String email;

    public User(@NonNull String name, @NonNull String email) {
        this.name = name;
        this.email = email;
    }

    public User() {
    }

    @Override
    public String toString() {
        return "User [id=" + id + ", name=" + name + ", email=" + email + "]";
    }

    public Long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    
}