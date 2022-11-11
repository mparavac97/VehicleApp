import React from "react";
import { ChangeEvent, useEffect, useState } from "react";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';

function ModelsAddEditForm(props: {
    item?: any; addItemToState?: (item: any) => void; updateState?(vehicle: any): void; toggle(): void;
}) {
    const [state, setState] = useState<any>({ID: 0, MakeID:'', Name:'', Abbreviation:''});

    function onChange (event: ChangeEvent<HTMLInputElement> ) {
       setState((prevState: any) => ({...prevState, [event.target.name]: event.target.value}));
    }

    function submitFormAdd(e: { preventDefault: () => void; }) {
        e.preventDefault();
        fetch('https://localhost:44370/api/VehicleModels', {
            method: 'post',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify({
                ID: state.ID,
                MakeID: state.MakeID,
                Name: state.Name,
                Abbreviation: state.Abbreviation
            })
        })  
        .then(response => response.json()) 
        .then(item => {
            if (item.length !== 0) {
                props.addItemToState?.(item);
                props.toggle();
            }
            else {
                console.log('fail')
            }
        }) 
    }

    function submitFormEdit() {
        fetch('https://localhost:44370/api/VehicleModels/', {
            method: 'put',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                ID: state.ID,
                MakeID: state.MakeID,
                Name: state.Name,
                Abbreviation: state.Abbreviation
            })
        })
        .then(response => response.json)
        .then(item => {
            if(item.length !== 0) {
                props.updateState?.(item);
                props.toggle();
            }
        })
    }

    useEffect(() => {
        if(props.item) {
            const {ID, MakeID, Name, Abbreviation} = props.item
            setState({ID, MakeID, Name, Abbreviation})
        }
    }, [props.item])

    return (
        <Form onSubmit={props.item ? submitFormEdit : submitFormAdd}>
            <FormGroup>
                <Label for="ID">ID</Label>
                <Input type="text" name="ID" id="ID" onChange={onChange} value={state.ID === null ? '' : state.ID} />
            </FormGroup>
            <FormGroup>
                <Label for="MakeID">MakeID</Label>
                <Input type="text" name="MakeID" id="MakeID" onChange={onChange} value={state.MakeID === null ? '' : state.MakeID} />
            </FormGroup>
            <FormGroup>
                <Label for="Name">Name</Label>
                <Input type="text" name="Name" id="Name" onChange={onChange} value={state.Name === null ? '' : state.Name} />
            </FormGroup>
            <FormGroup>
                <Label for="Abbreviation">Abbreviation</Label>
                <Input type="text" name="Abbreviation" id="Abbreviation" onChange={onChange} value={state.Abbreviation === null ? '' : state.Abbreviation} />
            </FormGroup>
            <Button>Submit</Button>
        </Form>
    )
}

export default ModelsAddEditForm;