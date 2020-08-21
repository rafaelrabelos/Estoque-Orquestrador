import React from "react";
import Paper from '@material-ui/core/paper';
import { ObtemProdutos } from 'Fluxos/Produto/ProdutoController';
import ProdutoItemComp from 'views/ComponentesComuns/ProdutoItemComp';
import CollapseItem from 'views/ComponentesComuns/CollapseItem';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { Spinner, Button, Card, CardHeader, CardBody, Row, Col, Container, Input} from "reactstrap";
import { SalvaProduto } from 'Fluxos/Produto/ProdutoController';
import { ShakeMe } from 'views/ComponentesComuns/ShakeDiv';
toast.configure({ autoClose: 4000 });


class Home extends React.Component {

  constructor(props) {
    super(props);

    this.state = {
        ListaProdutosComponente: <Spinner type="grow" />,
        ProdutoContent : <Spinner type="grow" />,
        CollapseIsOpen : false,
        NomeProduto : "",
        QtdProduto : 0,
        ValorProduto : 0,
        CheckNameMsg : ""
    };
  }

  salvarNovo = async () => {

    const {NomeProduto, QtdProduto, ValorProduto} = this.state;

    if(NomeProduto === "")
    {
        this.setState({CheckNameMsg:""}, ()=>this.setState({CheckNameMsg:"Campo deve ser informado"}));
        return;
    }

    if(this.state.CheckNameMsg !== "")
        this.setState({CheckNameMsg:""});
    
        

    let result = await SalvaProduto( NomeProduto, QtdProduto, parseFloat(ValorProduto.toString().replace(",",".")) );

    if(result.status &&  result.resposta.length === 1 ){


        toast.success("Produto Gravado Com Sucesso!",
            {
                position: toast.POSITION.BOTTOM_RIGHT,
                onClose: () =>{ this.toggle(); this.componentDidMount() }
            });
    }

    console.log(result)
}

  onChangeInput = (e) => this.setState({  [e.target.name]: e.target.value } )
  onChangeInputNum= (e) => this.setState({ [e.target.name] : e.target.value === "" ? "0" : e.target.value }) 

  toggle = () =>{  this.setState({ CollapseIsOpen : !this.state.CollapseIsOpen } )}


    componentDidMount = async() => {

    let produtos = await ObtemProdutos();

    console.log(produtos);

    if( produtos.status ){
       let lista =  produtos.resposta.map( item => 
        <ProdutoItemComp
        key={item.id}
        ItemKey={item.id}
        nome={item.nome}
        id={item.id}
        valor={item.valor}
        excluido={item.excluido}
        qtd={item.qtd} 
        />)

        this.setState({
            ListaProdutosComponente : lista
        })
    }

  }

  render() {
    return (
        <>
            {/* Page content */}
            <Container className=" mt--7" fluid>
                <Row>
                    <div className=" col">
                        <Card className=" shadow">
                            <CardHeader className=" bg-transparent"> <h3 className=" mb-0"> Produtos </h3></CardHeader>
                            <CardBody>
                                <br />
                                <Container style={{ marginLeft: 0, marginRight: 0 }} >
                                    <Row>
                                        <Col xs="8">
                                            <Button size="md" color="success" onClick={() => this.toggle()}> {this.state.CollapseIsOpen ? "Cancelar":"Adicionar"}</Button>
                                        </Col>
                                    </Row>
                                    <CollapseItem isOpen={this.state.CollapseIsOpen} >
                                        <br />
                                            <ul className="nav nav-tabs" id={"myTab_" + this.props.id} role="tablist">
                                                <li className="nav-item">
                                                    <a className="nav-link active" id={"basico-tab" + this.props.id}  data-toggle="tab" href={"#basico" + this.props.id}  role="tab" aria-controls="home" aria-selected="true">Adicionar</a>
                                                </li>
                                            </ul>
                                            <div className="tab-content" id="myTabContent">
                                                <div className="tab-pane fade show active" id={"basico" + this.props.id}  role="tabpanel" aria-labelledby={"basico-tab" + this.props.id} >
                                                    <Paper>
                                                        <Row>
                                                            <Col xs="6" md="6">
                                                                <ShakeMe bindValueChange={this.state.CheckNameMsg} >
                                                                    <Input 
                                                                        bsSize="sm"
                                                                        type="text"
                                                                        required
                                                                        id={this.props.id + "_nam"}
                                                                        name="NomeProduto"
                                                                        placeholder="Nome Produto"
                                                                        value={ this.state.NomeProduto }
                                                                        onChange={(e) => this.onChangeInput(e) } 
                                                                    /><small><font color="red">{this.state.CheckNameMsg}</font></small>
                                                                </ShakeMe>
                                                                <Input 
                                                                    bsSize="sm"
                                                                    type='number'
                                                                    required
                                                                    id={this.props.id + "_qtd"}
                                                                    name={"QtdProduto"}
                                                                    placeholder="Qtd Produto"
                                                                    value={ this.state.QtdProduto}
                                                                    onChange={(e) => this.onChangeInputNum(e) } 
                                                                />
                                                                <Input 
                                                                    bsSize="sm"
                                                                    type='text'
                                                                    required
                                                                    id={this.props.id + "_val"}
                                                                    name={"ValorProduto"}
                                                                    placeholder="Valor Produto"
                                                                    value={ this.state.ValorProduto.toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2}) }
                                                                    onChange={(e) => this.onChangeInputNum(e) }
                                                                    onBlur={ (e)=> this.setState({ValorProduto: parseFloat(e.target.value.replace(",",".")).toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2}) }) }
                                                                />
                                                                </Col>
                                                                <Col xs="4" md="4">
                                                                    <br />
                                                                    <Button size="sm" color="warning" onClick={() => this.toggle() }>cancelar</Button>
                                                                    <Button size="sm" color="success" onClick={() => this.salvarNovo()}>salvar</Button>
                                                                </Col>
                                                        </Row>
                                                    </Paper>
                                                </div>

                                            </div>
                                        </CollapseItem>
                                </Container>
                                <br />
                                <Paper id="paperTaxas" >  { this.state.ListaProdutosComponente } </Paper>
                            </CardBody>
                        </Card>
                    </div>
                </Row>
            </Container>
        </>
    );
  }
}

export default Home;
