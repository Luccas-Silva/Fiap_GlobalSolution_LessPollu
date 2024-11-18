package com.GlobalSolution.LessPollu.gateways;

import com.GlobalSolution.LessPollu.domains.Usuario;
import org.springframework.data.jpa.repository.JpaRepository;

public interface UsuarioRepository extends JpaRepository<Usuario, String> {
}
