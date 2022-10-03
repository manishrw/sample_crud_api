package com.manishrw.spring_mvc_app.service;

import java.util.List;

import com.manishrw.spring_mvc_app.exception.UserNotFoundException;
import com.manishrw.spring_mvc_app.exception.UserServiceException;
import com.manishrw.spring_mvc_app.model.User;

public interface UserService {
    List<User> getUsers() throws UserServiceException;
    User getUserById(long userId) throws UserNotFoundException, UserServiceException;
    User saveUser(User user) throws UserServiceException;
    void deleteUser(long userId) throws UserNotFoundException, UserServiceException;
}
