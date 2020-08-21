import React from "react";
import Paper from '@material-ui/core/paper';
import CollapseItem from 'views/ComponentesComuns/CollapseItem';
import { ListGroupItem, Badge, Spinner, Button, Col, Input, Row} from "reactstrap";
import { DeletaProduto, AtualizaProduto } from 'Fluxos/Produto/ProdutoController';
import { ShakeMe } from 'views/ComponentesComuns/ShakeDiv';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

toast.configure({ autoClose: 4000 });

class ProdutoItemComp extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            Componente : <Spinner type="grow" />,
            CollapseIsOpen : false,
            ComponenteOpcoes:<Spinner type="grow" />,
            Nome : this.props.nome,
            Qtd : this.props.qtd,
            Valor : this.props.valor,
            NomeProduto : this.props.nome,
            QtdProduto : this.props.qtd,
            ValorProduto : this.props.valor,
            CheckNameMsg : ""
        }
    }

    toggle = () =>{  this.setState({ CollapseIsOpen : !this.state.CollapseIsOpen } )}

    onChangeInput = (e) => this.setState({  [e.target.name]: e.target.value })
    onChangeInputNum= (e) => this.setState({ [e.target.name] : e.target.value === "" ? "0" : e.target.value }) 
    
    editarProduto() {
       
        this.setState({
            NomeProduto : this.state.Nome,
            QtdProduto : this.state.Qtd,
            ValorProduto : this.state.Valor
        }, () => this.toggle() )
    }

    excluirProduto = async (e) =>{

        let result = await DeletaProduto(this.props.id);

        if(result.status &&  result.resposta.length === 1 && result.resposta[0].excluido){

            toast.success("Produto Deletado Com Sucesso!",
                {
                    position: toast.POSITION.BOTTOM_RIGHT,
                    onClose: () =>{ this.setState({Componente : ()=><></> }) }
                });
        }
    };

    salvarEdicao = async () => {

        const {NomeProduto, QtdProduto, ValorProduto} = this.state;

        if(NomeProduto === "")
        {
            this.setState({CheckNameMsg:""}, ()=>this.setState({CheckNameMsg:"Campo deve ser informado"}));
            return;
        }

        if(this.state.CheckNameMsg !== "")
            this.setState({CheckNameMsg:""});

        let result = await AtualizaProduto(this.props.id, NomeProduto, QtdProduto, parseFloat(ValorProduto.toString().replace(",",".")) );

        if(result.status &&  result.resposta.length === 1 ){

            this.setState({
                Nome : result.resposta[0].nome,
                Qtd : result.resposta[0].qtd,
                Valor : result.resposta[0].valor,
            })

            toast.success("Produto Atualizado com Sucesso!",
                {
                    position: toast.POSITION.BOTTOM_RIGHT,
                    onClose: () =>{ this.toggle() }
                });
        }

        console.log(result)
    }

    componente = () => 
    <>
        <ListGroupItem 
            className="checklist-entry flex-column align-items-start py-3 px-4 list-group-item" 
            key={`ListProfissionaGroupItem_${this.props.ItemKey}`}>
            <div className={`checklist-item checklist-item-secondary`} >
                <div className="checklist-info">
                    <div className="h4 checklist-title mb-0"> { this.state.Nome } </div>
                    <div className="h3 checklist-title mb-0">
                        <Badge color="primary" pill> <b>id:</b> { this.props.id }</Badge>
                        <Badge color="success" pill><b>Status :</b> { !this.props.excluido ? "OK" : "Excluído" }</Badge>
                        <Badge color={ this.state.Qtd > 3 ? "success":"warning"} pill><b>Qtd :</b> { this.state.Qtd }</Badge>
                    </div>
                </div>
                <Badge color="primary" pill><b>Valor :</b> R${ this.state.Valor.toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2}) }</Badge>
                <div>
                    <div className={`custom-control custom-checkbox custom-checkbox-primary`}>
                        <div className="btn-group-toggle" data-toggle="buttons">
                            <div className="h5 checklist-title mb-0" id={ "ttip" + this.props.ItemKey }>
                                <h2>
                                    <Button size="sm" color="primary" onClick={() => this.editarProduto()}> <i className="text-white mr-2 fa fa-edit" ></i>Editar</Button>
                                    <Button size="sm" color="danger" onClick={() => this.excluirProduto()}> <i className="text-white mr-2 fa fa-edit" ></i>Excluir</Button>
                                </h2>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <CollapseItem isOpen={this.state.CollapseIsOpen} >
            <br />
                <ul className="nav nav-tabs" id={"myTab_" + this.props.id} role="tablist">
                    <li className="nav-item">
                        <a className="nav-link active" id={"basico-tab" + this.props.id}  data-toggle="tab" href={"#basico" + this.props.id}  role="tab" aria-controls="home" aria-selected="true">Editar</a>
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
                                        value={this.state.ValorProduto.toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2})}
                                        onChange={(e) => this.onChangeInputNum(e) }
                                        onBlur={ (e)=> this.setState({ValorProduto: parseFloat(e.target.value.replace(",",".")).toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2}) }) }
                                    />
                                    </Col>
                                    <Col xs="4" md="4">
                                        <br />
                                        <Button size="sm" color="warning" onClick={() => this.toggle() }>cancelar</Button>
                                        <Button size="sm" color="success" onClick={() => this.salvarEdicao()}>salvar</Button>
                                    </Col>
                            </Row>
                        </Paper>
                    </div>

                </div>
            </CollapseItem>
        </ListGroupItem>
    </>


    componentWillMount = () => this.setState({Componente : this.componente})

    render = () => this.state.Componente();//this.componente()

    
}

export default ProdutoItemComp;
