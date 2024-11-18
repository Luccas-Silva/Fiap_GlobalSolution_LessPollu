package com.GlobalSolution.LessPollu.gateways;

import com.GlobalSolution.LessPollu.domains.Industria;
import com.GlobalSolution.LessPollu.domains.Usuario;
import lombok.RequiredArgsConstructor;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.hateoas.EntityModel;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Map;
import java.util.Optional;

import static org.springframework.hateoas.server.mvc.WebMvcLinkBuilder.linkTo;
import static org.springframework.hateoas.server.mvc.WebMvcLinkBuilder.methodOn;

@RestController
@RequestMapping("/industria")
@RequiredArgsConstructor
@Validated
public class IndustriaController {

    private final IndustriaRepository industriaRepository;

    @GetMapping
    public ResponseEntity<EntityModel<Map<String, String>>> comandosIndustria() {

        EntityModel<Map<String, String>> entityModel = EntityModel.of(Map.of());

        // Add self link
        entityModel.add(linkTo(methodOn(IndustriaController.class).comandosIndustria()).withSelfRel());

        // Add links to other relevant endpoints
        entityModel.add(linkTo(methodOn(IndustriaController.class).getAllIndustrias()).withRel("listar-industrias"));
        entityModel.add(linkTo(methodOn(IndustriaController.class).getIndustriaById("/{Id}")).withRel("obter-industria"));
        entityModel.add(linkTo(methodOn(IndustriaController.class).deleteIndustria("/{Id}")).withRel("deletar-industria"));
        entityModel.add(linkTo(methodOn(IndustriaController.class).createIndustria(null)).withRel("criar-industria"));

        return ResponseEntity.ok(entityModel);
    }

    @GetMapping("/{Id}")
    public ResponseEntity<Optional<Industria>> getIndustriaById(@PathVariable String Id) {
        Optional<Industria> optionalIndustria = industriaRepository.findById(Id);
        return ResponseEntity.ok(optionalIndustria);
    }

    @GetMapping("/Industrias")
    public ResponseEntity<List<Industria>> getAllIndustrias() {
        List<Industria> industrias = industriaRepository.findAll();
        return ResponseEntity.ok(industrias);
    }

    @PostMapping
    public ResponseEntity<Industria> createIndustria(@RequestBody Industria industria) {
        Industria industriaSalvo = industriaRepository.save(industria);
        return ResponseEntity.status(HttpStatus.CREATED).body(industriaSalvo);
    }

    @DeleteMapping("/{Id}")
    public ResponseEntity<Void> deleteIndustria(@PathVariable String Id) {
        try {
            industriaRepository.deleteById(Id);
            return ResponseEntity.noContent().build();
        } catch (DataIntegrityViolationException e) {
            throw new RuntimeException("Não é possível excluir o industria devido a dependências.", e);
        } catch (Exception e) {
            throw new RuntimeException("Erro inesperado ao excluir o industria.", e);
        }
    }

}
