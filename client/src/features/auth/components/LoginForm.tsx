import { z } from "zod";

import { Form } from "@/components/Form";

const schema = z.object({
  email: z.string().min(1, "Required"),
  password: z.string().min(1, "Required"),
});

type LoginValues = {
  email: string;
  password: string;
};

export function LoginForm() {
  return (
    <div>
      <Form<LoginValues, typeof schema>>
        {({ register, formState }) => <div />}
      </Form>
    </div>
  );
}
