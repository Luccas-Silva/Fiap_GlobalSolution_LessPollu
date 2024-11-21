package com.GlobalSolution.LessPollu.gateways;

import com.GlobalSolution.LessPollu.domains.Relatorio;
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
@RequestMapping("/relatorio")
@RequiredArgsConstructor
@Validated
public class RelatorioController {

    private final RelatorioRepository relatorioRepository;

    @GetMapping
    public ResponseEntity<EntityModel<Map<String, String>>> comandosRelatorio() {

        EntityModel<Map<String, String>> entityModel = EntityModel.of(Map.of());

        // Add self link
        entityModel.add(linkTo(methodOn(RelatorioController.class).comandosRelatorio()).withSelfRel());

        // Add links to other relevant endpoints
        entityModel.add(linkTo(methodOn(RelatorioController.class).getAllRelatorios()).withRel("listar-relatorios"));
        entityModel.add(linkTo(methodOn(RelatorioController.class).getRelatorioById("/{Id}")).withRel("obter-relatorio"));
        entityModel.add(linkTo(methodOn(RelatorioController.class).deleteRelatorio("/{Id}")).withRel("deletar-relatorio"));
        entityModel.add(linkTo(methodOn(RelatorioController.class).createRelatorio(null)).withRel("criar-relatorio"));

        return ResponseEntity.ok(entityModel);
    }

    @GetMapping("/{Id}")
    public ResponseEntity<Optional<Relatorio>> getRelatorioById(@PathVariable String Id) {
        Optional<Relatorio> optionalRelatorio = relatorioRepository.findById(Id);
        return ResponseEntity.ok(optionalRelatorio);
    }

    @GetMapping("/relatorios")
    public ResponseEntity<List<Relatorio>> getAllRelatorios() {
        List<Relatorio> relatorios = relatorioRepository.findAll();
        return ResponseEntity.ok(relatorios);
    }


    @PostMapping
    public ResponseEntity<Relatorio> createRelatorio(@RequestBody Relatorio relatorio) {
        Relatorio relatorioSalvo = relatorioRepository.save(relatorio);
        return ResponseEntity.status(HttpStatus.CREATED).body(relatorioSalvo);
    }

    @DeleteMapping("/{Id}")
    public ResponseEntity<Void> deleteRelatorio(@PathVariable String Id) {
        try {
            relatorioRepository.deleteById(Id);
            return ResponseEntity.noContent().build();
        } catch (DataIntegrityViolationException e) {
            throw new RuntimeException("Não é possível excluir o relatorio devido a dependências.", e);
        } catch (Exception e) {
            throw new RuntimeException("Erro inesperado ao excluir o relatorio.", e);
        }
    }

}
