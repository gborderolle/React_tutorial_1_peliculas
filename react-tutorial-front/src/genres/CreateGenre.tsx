import FormGenre from "./FormGenre";

export default function CreateGenre() {
  return (
    <>
      <FormGenre
        formName="Crear género"
        model={{ name: '' }}
        onSubmit={async (values) => {
          await new Promise(r => setTimeout(r, 1000))
          console.log(values);
        }}
      />
    </>
  );
}
