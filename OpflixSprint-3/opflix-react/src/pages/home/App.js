import React from 'react';
import './App.css';

//Imortando O Link do react-router-dom para voce clicar na sua navbar e ela ser redirecionada para sua url correspondente de sua página
import { Link } from "react-router-dom";
import '../../assets/css/home.css'
import fundo from '../../assets/img/fundo-roxo_1057-4682.jpg';
import filme1 from '../../assets/img/avengers.jpg';
import filme2 from '../../assets/img/carrinhos.jpg';
import filme3 from '../../assets/img/culpa-das-estrelas.jpg';
import filme4 from '../../assets/img/vovozona.jpg';


function App() {
  return (
    <div className="App">
      <header className="menuzao">
        <nav className="menu">
          <ul>
            <li id="menuzin">
              <h1>OPFLIX</h1>
              <Link to='/cadastro'>Cadastre-se</Link>
              <Link to='/login'>Login</Link>
              <Link to='/lancamentos'>Lançamentos</Link>
              <Link to='/categorias'>Categorias</Link>
              <Link to='/localizacoes'>Localizacoes</Link>
            </li>
          </ul>
        </nav>
      </header>
      <section className="banner">
        <div className="titulo-banner">
          <h2>Gosta de ficar inteirado nos melhores títulos do cinema? Aqui é seu lugar!</h2>
        </div>
      </section>
      <div className="fundo-site">
        <h2 className="titulo-sections">Destaques:</h2>
        <section className="section-1">
          <img className="foto-da-home-1" src={filme1} />
          <p className="texto-da-home">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec molestie dignissim sem eu mattis. Donec tincidunt lectus lectus, in egestas turpis blandit id. Cras condimentum augue vitae gravida scelerisque. Pellentesque pretium varius enim. Donec facilisis nibh dolor, vitae interdum dui egestas vitae. Quisque quis quam odio. Vestibulum commodo lorem ut velit consectetur, ac aliquet nisl auctor. Donec quis velit enim. Integer ultrices ligula in posuere imperdiet.</p>
        </section>
        <section className="section-2">

          <p className="texto-da-home">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec molestie dignissim sem eu mattis. Donec tincidunt lectus lectus, in egestas turpis blandit id. Cras condimentum augue vitae gravida scelerisque. Pellentesque pretium varius enim. Donec facilisis nibh dolor, vitae interdum dui egestas vitae. Quisque quis quam odio. Vestibulum commodo lorem ut velit consectetur, ac aliquet nisl auctor. Donec quis velit enim. Integer ultrices ligula in posuere imperdiet.</p>
          <img className="foto-da-home-2" src={filme1} />
        </section>
        <section className="section-1">

          <img className="foto-da-home-1" src={filme1} />
          <p className="texto-da-home">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec molestie dignissim sem eu mattis. Donec tincidunt lectus lectus, in egestas turpis blandit id. Cras condimentum augue vitae gravida scelerisque. Pellentesque pretium varius enim. Donec facilisis nibh dolor, vitae interdum dui egestas vitae. Quisque quis quam odio. Vestibulum commodo lorem ut velit consectetur, ac aliquet nisl auctor. Donec quis velit enim. Integer ultrices ligula in posuere imperdiet.</p>
        </section>
        <section className="section-2">
          <p className="texto-da-home">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec molestie dignissim sem eu mattis. Donec tincidunt lectus lectus, in egestas turpis blandit id. Cras condimentum augue vitae gravida scelerisque. Pellentesque pretium varius enim. Donec facilisis nibh dolor, vitae interdum dui egestas vitae. Quisque quis quam odio. Vestibulum commodo lorem ut velit consectetur, ac aliquet nisl auctor. Donec quis velit enim. Integer ultrices ligula in posuere imperdiet.</p>
          <img className="foto-da-home-2" src={filme1} />
        </section>
        <h2 class="titulo-perto-do-footer">Cadastre-se e saiba mais! </h2>
        <br/>
      </div>
      <footer id="rodape2">
        <p>redes sociais: blablabla@gmail.com</p>
        <p>facebook: opflix series official</p>
        <p>Todos os direitos reservados</p>
      </footer>
    </div>
  );
}

export default App;