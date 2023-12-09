﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace RestauranteSanduba.Test.Core.ApplicationTest.Cardapio
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CadastroDeProdutosFeature : object, Xunit.IClassFixture<CadastroDeProdutosFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CadastroDeProdutos.feature"
#line hidden
        
        public CadastroDeProdutosFeature(CadastroDeProdutosFeature.FixtureData fixtureData, RestauranteSanduba_Test_Core_ApplicationTest_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "Cardapio", "Cadastro de produtos", "\tComo administrador do resturante\r\n\tEu quero adicionar um novo produto no cardápi" +
                    "o\r\n\tPara que os clientes possam adicionar esse novo produto no pedido", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Adicionar um novo produto no cardápio")]
        [Xunit.TraitAttribute("FeatureTitle", "Cadastro de produtos")]
        [Xunit.TraitAttribute("Description", "Adicionar um novo produto no cardápio")]
        public void AdicionarUmNovoProdutoNoCardapio()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Adicionar um novo produto no cardápio", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 8
 testRunner.Given("temos um novo \"Lanche\" chamado \"Mega Lanche\" com a descrição de \"Nosso mega lanch" +
                        "e\" e com preço de 15,99", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 9
 testRunner.When("adicionar o novo lanche no cardápio", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 10
 testRunner.Then("deve retornar o novo código cadastrado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Adicionar um produto já existente no cardápio")]
        [Xunit.TraitAttribute("FeatureTitle", "Cadastro de produtos")]
        [Xunit.TraitAttribute("Description", "Adicionar um produto já existente no cardápio")]
        public void AdicionarUmProdutoJaExistenteNoCardapio()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Adicionar um produto já existente no cardápio", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 12
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 13
 testRunner.Given("temos um lanche chamado \"Mega Lanche\" já cadastrado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 14
 testRunner.When("adicionar o lanche existente no cardápio", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 15
 testRunner.Then("deve retornar erro informando a duplicidade", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Adicionar um novo produto com descrição inválida")]
        [Xunit.TraitAttribute("FeatureTitle", "Cadastro de produtos")]
        [Xunit.TraitAttribute("Description", "Adicionar um novo produto com descrição inválida")]
        public void AdicionarUmNovoProdutoComDescricaoInvalida()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Adicionar um novo produto com descrição inválida", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 17
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 18
 testRunner.Given("temos um novo \"Lanche\" chamado \"Mega Lanche\" com a descrição de vazia e com preço" +
                        " de 15,99", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 19
 testRunner.When("adicionar o novo lanche no cardápio", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 20
 testRunner.Then("deve retornar erro informando a descrição inválida", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CadastroDeProdutosFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CadastroDeProdutosFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
