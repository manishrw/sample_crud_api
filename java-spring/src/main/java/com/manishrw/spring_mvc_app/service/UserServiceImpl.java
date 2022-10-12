package com.manishrw.spring_mvc_app.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.manishrw.spring_mvc_app.exception.UserNotFoundException;
import com.manishrw.spring_mvc_app.exception.UserServiceException;
import com.manishrw.spring_mvc_app.model.User;
import com.manishrw.spring_mvc_app.repository.UserRepository;

@Service
public class UserServiceImpl implements UserService {
    
    @Autowired
    private UserRepository userRepository;

    @Override
    public List<User> getUsers() {
        try {
            return userRepository.findAll();
        } catch (Exception e) {
            throw new UserServiceException(e.getLocalizedMessage());
        }
    }

    @Override
    public User getUserById(long userId) {
        try {
            var user = userRepository.findById(userId);
            if (user.isPresent()) {
                return user.get();
            } else {
                throw new UserNotFoundException();
            }
        } catch (Exception e) {
            throw new UserServiceException(e.getLocalizedMessage());
        }
    }

    @Override
    public User saveUser(User user) {
        try {
            return userRepository.save(user);
        } catch (Exception e) {
            throw new UserServiceException(e.getLocalizedMessage());
        }
    }

    @Override
    public void deleteUser(long userId) {
        try {
            var user = userRepository.findById(userId);
            if (user.isPresent()) {
                userRepository.delete(user.get());
            } else {
                throw new UserNotFoundException();
            }
        } catch (Exception e) {
            throw new UserServiceException(e.getLocalizedMessage());
        }
    }
}
