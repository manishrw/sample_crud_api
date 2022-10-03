package com.manishrw.spring_mvc_app.controller;

import java.util.List;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.manishrw.spring_mvc_app.model.User;
import com.manishrw.spring_mvc_app.service.UserService;

@RestController
@RequestMapping("/api/users")
public class UserController {
    
    @Autowired
    private UserService userService;

    private Logger logger = LoggerFactory.getLogger(UserController.class);

    @GetMapping
    @ResponseBody
    public List<User> findAll() {
        logger.info("Getting all users");
        return userService.getUsers();
    }

    @GetMapping("/{id}")
    @ResponseBody
    public User findById(@PathVariable long  id) {
        logger.info("Getting user with id: {}", id);
        return userService.getUserById(id);
    }

    @PutMapping
    @ResponseBody
    public User save(@RequestBody User user) {
        logger.info("Saving user: {}", user);
        return userService.saveUser(user);
    }

    @DeleteMapping("/{id}")
    @ResponseBody
    public Boolean delete(@PathVariable long id) {
        logger.info("Deleting user with id: {}", id);
        userService.deleteUser(id);
        return true;
    }

}
