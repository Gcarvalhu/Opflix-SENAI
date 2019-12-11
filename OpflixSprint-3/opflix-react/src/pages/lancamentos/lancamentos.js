import React, { Component } from "react";
import Axios from "axios";
import { parseJwt } from "../../services/autenticacao";
import { Link } from "react-router-dom";

import '../../assets/css/lancamentos.css';

export default class Lancamentos extends Component {
    constructor() {
        super();
        this.state = {
            lista: [],
            listaDeCategoria: [],
            listaDePlataforma: [],
            token: "",
            titulo: "",
            sinopse: "",
            tipo: "",
            datalanc: "",
            duracao: "",
            idCategoria: "",
            idPlataforma: "",
        }
    }


    componentDidMount() {
        this.setState({ token: parseJwt() })
        this.convertToken();
        this.listarLancamentos();
        this.listaDeCategoria();
        this.listaDePlataforma();
    }

    convertToken = () => {
        console.log(parseJwt())
    }

    listarLancamentos = () => {
        Axios.get('http://192.168.4.183:5000/api/lancamentos', {
            headers: {
                Authorization: "Bearer " + localStorage.getItem("usuario-opflix")
            }
        })
            .then(response => {
                this.setState({ lista: response.data })
            })
            .catch(erro => console.log(erro))
    }
    cadastrarLancamentos = (event) => {
        // event.preventDefault();
        fetch('http://192.168.4.183:5000/api/lancamentos', {
            method: "POST",
            body: JSON.stringify({
                titulo: this.state.titulo,
                sinopse: this.state.sinopse,
                tipo: this.state.tipo,
                dataLanc: this.state.datalanc,
                duracao: this.state.duracao,
                idCategoria: this.state.idCategoria,
                idPlataforma: this.state.idPlataforma
            }),
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + localStorage.getItem("usuario-opflix")
            }
        })
            .then(response => this.listarLancamentos())
            .catch(erro => console.log(erro))
    }
    titulo = (event) => {
        this.setState({ titulo: event.target.value });
        console.log(this.state);
    }
    sinopse = (event) => {
        this.setState({ sinopse: event.target.value });
        console.log(this.state);
    }
    tipo = (event) => {
        this.setState({ tipo: event.target.value });
        console.log(this.state);
    }
    dataLanc = (event) => {
        this.setState({ datalanc: event.target.value });
        console.log(this.state);
    }
    duracao = (event) => {
        this.setState({ duracao: event.target.value });
        console.log(this.state);
    }
    categoria = (event) => {
        this.setState({ idCategoria: event.target.value });
        console.log(this.state);
    }
    plataforma = (event) => {
        this.setState({ idPlataforma: event.target.value });
        console.log(this.state);
    }
    Logout() {
        localStorage.clear();
        window.location.href = '/';
    }

    listaDeCategoria = () => {

        var config = {
            headers: { 'Authorization': "bearer " + localStorage.getItem("usuario-opflix") }
        };

        Axios.get('http://192.168.4.183:5000/api/categoria',
            config
        ).then((response) => {
            this.setState({ listaDeCategoria: response.data })
        })
        console.log(this.state.lista)
    }

    listaDePlataforma = () => {
        var config = {
            headers: { 'Authorization': "bearer " + localStorage.getItem("usuario-opflix") }
        };

        Axios.get('http://192.168.4.183:5000/api/plataforma',
            config
        ).then((response) => {
            this.setState({ listaDePlataforma: response.data })
        })
        console.log(this.state.lista)
    }
    render() {
        return (
            <div className="lancamentos">
                <header className="menuzao">
                    <nav className="menu">
                        <ul>
                            <li id="menuzin">
                                <h1>OPFLIX</h1>
                                <a href="/">Início</a>
                                <a href="/" onClick={this.Logout}>LOGOUT</a>
                                <Link to='/categorias'>Categorias</Link>
                                <Link to='/localizacoes'>Localizacoes</Link>
                            </li>
                        </ul>
                    </nav>
                </header>
                <h1>Lançamentos</h1>
                <table  id="tabelinha">
                    <thead>
                        <tr>
                            <th>Titulo</th>
                            <th>Sinopse</th>
                            <th>Tipo</th>
                            <th>Data</th>
                            <th>Duração</th>
                            <th>Categoria</th>
                            <th>Plataforma</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.lista.map(element => {
                            console.log(element);
                            return (
                                <tr id="tabela-lancamentos">
                                    <td className="linhaTabela">{element.titulo}</td>
                                    <td className="linhaTabela">{element.sinopse}</td>
                                    <td className="linhaTabela">{element.tipo}</td>
                                    <td className="linhaTabela">{element.dataLanc}</td>
                                    <td className="linhaTabela">{element.duracao}</td>
                                    <td className="linhaTabela">{element.idCategoriaNavigation != undefined ? element.idCategoriaNavigation.nomeCategoria : 'Não possui categoria.'}</td>
                                    <td className="linhaTabela">{element.idPlataformaNavigation != undefined ? element.idPlataformaNavigation.nomePlataforma : 'Plataforma não cadastrada.'}</td>
                                </tr>
                            );
                        })}
                    </tbody>
                </table>
                <h1>Cadastrar Lançamentos</h1>
                <input placeholder="Titulo"
                    onChange={this.titulo} />
                <input
                    placeholder="Sinopse"
                    value={this.state.sinopse}
                    onChange={this.sinopse} />
                <input
                    placeholder="Tipo"
                    value={this.state.tipo}
                    onChange={this.tipo} />
                <input
                    placeholder="Data de lançamento"
                    type="date"
                    value={this.state.datalanc}
                    onChange={this.dataLanc} />
                <input
                    placeholder="Duração"
                    value={this.state.duracao}
                    onChange={this.duracao} />
                {/* <input placeholder="Categoria" value={this.state.idCategoria} onChange={this.categoria} /> */}
                {/* <input placeholder="Plataforma" value={this.state.idPlataforma} onChange={this.plataforma} /> */}
                <select id="option__tipoevento" placeholder="Categoria do Evento" onChange={this.categoria} value={this.state.idCategoria}>
                    <option value="0" disabled selected >Selecione a Categoria</option>
                    <option selected >Selecione</option>
                    {this.state.listaDeCategoria.map(element => {
                        return (
                            <option value={element.idCategoria}>{element.nomeCategoria}</option>
                        )
                    })}
                </select>
                <select id="option__tipoevento" placeholder="Categoria do Evento" onChange={this.plataforma} value={this.state.idPlataforma}>
                    <option value="0" disabled selected >Selecione a Plataforma</option>
                    <option selected>Selecione</option>
                    {this.state.listaDePlataforma.map(element => {
                        return (
                            <option value={element.idPlataforma}>{element.nomePlataforma}</option>
                        )
                    })}
                </select>
                <button className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro" onClick={this.cadastrarLancamentos}>Cadastrar</button>
                <footer id="rodape2">
                    <p>redes sociais: blablabla@gmail.com</p>
                    <p>facebook: opflix series official</p>
                    <p>Todos os direitos reservados</p>
                </footer>
            </div>
        );
    }
}