package com.GlobalSolution.LessPollu.gateways;

import lombok.RequiredArgsConstructor;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/relatorio")
@RequiredArgsConstructor
@Validated
public class RelatorioController {
}
