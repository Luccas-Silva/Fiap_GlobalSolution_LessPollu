package com.GlobalSolution.LessPollu.gateways;

import com.GlobalSolution.LessPollu.domains.Usuario;
import lombok.RequiredArgsConstructor;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;
import org.springframework.hateoas.EntityModel;

import java.util.List;
import java.util.Map;
import java.util.Optional;

import static org.springframework.hateoas.server.mvc.WebMvcLinkBuilder.linkTo;
import static org.springframework.hateoas.server.mvc.WebMvcLinkBuilder.methodOn;

@RestController
@RequestMapping("/usuario")
@RequiredArgsConstructor
@Validated
public class UsuarioController {

    private final UsuarioRepository usuarioRepository;

    @GetMapping
    public ResponseEntity<EntityModel<Map<String, String>>> comandosUsuario() {

        EntityModel<Map<String, String>> entityModel = EntityModel.of(Map.of());

        // Add self link
        entityModel.add(linkTo(methodOn(UsuarioController.class).comandosUsuario()).withSelfRel());

        // Add links to other relevant endpoints
        entityModel.add(linkTo(methodOn(UsuarioController.class).getAllUsuarios()).withRel("listar-usuarios"));
        entityModel.add(linkTo(methodOn(UsuarioController.class).getUsuarioById("/{Id}")).withRel("obter-usuario"));
        entityModel.add(linkTo(methodOn(UsuarioController.class).deleteUsuario("/{Id}")).withRel("deletar-usuario"));
        entityModel.add(linkTo(methodOn(UsuarioController.class).createUsuario(null)).withRel("criar-usuario"));

        return ResponseEntity.ok(entityModel);
    }

    @GetMapping("/{Id}")
    public ResponseEntity<Optional<Usuario>> getUsuarioById(@PathVariable String Id) {
        Optional<Usuario> optionalUsuario = usuarioRepository.findById(Id);
        return ResponseEntity.ok(optionalUsuario);
    }

    @GetMapping("/usuarios")
    public ResponseEntity<List<Usuario>> getAllUsuarios() {
        List<Usuario> usuarios = usuarioRepository.findAll();
        return ResponseEntity.ok(usuarios);
    }

    @PostMapping
    public ResponseEntity<Usuario> createUsuario(@RequestBody Usuario usuario) {
        Usuario usuarioSalvo = usuarioRepository.save(usuario);
        return ResponseEntity.status(HttpStatus.CREATED).body(usuarioSalvo);
    }

    @DeleteMapping("/{Id}")
    public ResponseEntity<Void> deleteUsuario(@PathVariable String Id) {
        try {
            usuarioRepository.deleteById(Id);
            return ResponseEntity.noContent().build();
        } catch (DataIntegrityViolationException e) {
            throw new RuntimeException("Não é possível excluir o usuário devido a dependências.", e);
        } catch (Exception e) {
            throw new RuntimeException("Erro inesperado ao excluir o usuário.", e);
        }
    }

}
