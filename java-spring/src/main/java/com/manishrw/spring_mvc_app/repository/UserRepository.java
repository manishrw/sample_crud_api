package com.manishrw.spring_mvc_app.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.manishrw.spring_mvc_app.model.User;

public interface UserRepository extends JpaRepository<User, Long> {
    
}
