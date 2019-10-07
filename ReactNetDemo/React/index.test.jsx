import CommentBox from "./index";

describe("index tests", () => {
  it("should render", () => {
    const wrapper = shallow(<CommentBox />);
    expect(wrapper).toMatchSnapshot();
  });
});
