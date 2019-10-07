import RouterExample from "./routerExample";

describe("router example tests", () => {
  it("should render", () => {
    const wrapper = shallow(<RouterExample />);
    expect(wrapper).toMatchSnapshot();
  });

  it("should fail", () => {
    expect(1).toBe(1);
  });
});
